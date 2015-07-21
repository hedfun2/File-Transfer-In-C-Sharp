using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public class Server
    {
        TcpListener serverListener;
        TcpClient fileConnection;
        TcpClient messageConnection;

        bool canceled = false;
        bool successfulTransfer = false;
        AutoResetEvent waitHandle;
        bool sending = false;
        bool receiving = false;
        long totalBytesRead = 0;
        long receiveFileSize;
        String receiveFileLocation;
        List<String> filesToSend = new List<String>();
        StreamWriter sw;
        StreamReader sr;
        NetworkStream fileNS;
        NetworkStream messageNS;
        bool sentUsername = false;
        String username = Dns.GetHostName();
        MainWindow window;
        int serverPort;
        IPAddress serverIp;

        public Server(int port)
        {
            window = new MainWindow();
            window.Show();
            window.giveServer(this);
            this.serverPort = port;
            serverListener = new TcpListener(getLocalIp(), port);
            window.setConnectedText("Listening For Clients");
            listenForClients();
        }

        public Server(IPAddress serverIp, int port)
        {
            window = new MainWindow();
            window.Show();
            window.giveServer(this);
            this.serverIp = serverIp;
            this.serverPort = port;
            fileConnection = new TcpClient();
            messageConnection = new TcpClient();
            window.setConnectedText("Attempting to Connect to: " + serverIp.ToString() + ":" + port);
            Thread connectToServerThread = new Thread(new ThreadStart(connectToServer));
            connectToServerThread.Start();
            connectToServerThread.IsBackground = true;
        }

        public bool isTransfering()
        {
            return (sending || receiving);
        }

        public void cancelTransfer()
        {
            if (sending)
                window.sendMessageToUser("Canceled Upload");
            else if (receiving)
                window.sendMessageToUser("Canceled Download");
            else
            {
                window.sendMessageToUser("You are not sending or receiving a file");
                return;
            }
            canceled = true;
            setFilesToSend(null);
            sending = false;
            receiving = false;
            sendMessage("cancel");
        }

        public void setFilesToSend(String[] files)
        {
            filesToSend.Clear();
            if (files == null)
            {
                window.determineFilesSize(null);
                filesToSend.Clear();
                return;
            }

            window.determineFilesSize(files);
            foreach (String file in files)
            {
                window.sendMessageToUser("You've Selected: " + file);
                filesToSend.Add(file + "*" + new FileInfo(file).Length);
            }
        }

        public void sendAllFiles()
        {
            if (fileConnection == null || !fileConnection.Connected)
            {
                window.sendMessageToUser("You are not connected to anyone");
                MessageBox.Show("You are not connected to anyone");
                return;
            }
            else if (filesToSend.Count == 0)
            {
                window.sendMessageToUser("You haven't chose any files to send");
                MessageBox.Show("You haven't chose any files to send");
                return;
            }

            String fileName = filesToSend.ElementAt(0).Substring(filesToSend.ElementAt(0).LastIndexOf("\\") + 1);
            sendMessage("file" + fileName);
        }

        public void connectToServer()
        {
            do
            {
                try
                {
                    fileConnection.Connect(serverIp, serverPort);
                    messageConnection.Connect(serverIp, serverPort);
                }
                catch (SocketException e)
                {
                    Thread.Sleep(500);
                }
            } while (fileConnection.Connected == false);
            fileNS = fileConnection.GetStream();
            messageNS = messageConnection.GetStream();
            sw = new StreamWriter(messageNS);
            sr = new StreamReader(messageNS);
            Thread readMessageThread = new Thread(new ThreadStart(readMessages));
            readMessageThread.Start();
            readMessageThread.IsBackground = true;
            sendMessage(username);
        }

        public async void listenForClients()
        {
            serverListener.Start();
            fileConnection = await serverListener.AcceptTcpClientAsync();
            messageConnection = await serverListener.AcceptTcpClientAsync();
            fileNS = fileConnection.GetStream();
            messageNS = messageConnection.GetStream();
            sw = new StreamWriter(messageNS);
            sr = new StreamReader(messageNS);
            Thread readMessageThread = new Thread(new ThreadStart(readMessages));
            readMessageThread.Start();
            readMessageThread.IsBackground = true;
            sendMessage(username);
        }

        public IPAddress getLocalIp()
        {
            IPHostEntry host;
            IPAddress localIP = null;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip;
                    break;
                }
            }
            return localIP;
        }

        public void readMessages()
        {
            while (messageConnection.Connected)
            {
                String message = receiveMessages();
                if (message == null)
                {
                    return;
                }
                else if (!sentUsername)
                {
                    window.setConnectedText("Connected To " + message);
                    sentUsername = true;
                }
                else if (message.Substring(0, 4).Equals("file"))
                {
                    message = message.Substring(4);
                    receiveFileLocation = window.getFileSavePath() + "\\" + message.Substring(0, message.IndexOf('*'));
                    receiveFileSize = long.Parse(message.Substring(message.IndexOf('*') + 1));
                    Thread receiveFileThread = new Thread(new ThreadStart(receiveFile));
                    receiveFileThread.Start();
                    receiveFileThread.IsBackground = true;
                }
                else if (message.Substring(0, 4).Equals("fail"))
                {
                    MessageBox.Show("Failed To Send File: " + filesToSend.ElementAt(0).Substring(0, filesToSend.ElementAt(0).IndexOf('*')));
                    sending = false;
                }
                else if (message.Substring(0, 6).Equals("oksend"))
                {
                    Thread sendThread = new Thread(delegate()
                    {
                        sendFile(filesToSend.ElementAt(0).Substring(0, filesToSend.ElementAt(0).IndexOf('*')));
                    });
                    sendThread.Start();
                    sendThread.IsBackground = true;

                }
                else if (message.Substring(0, 6).Equals("cancel"))
                {
                    if (sending)
                        window.sendMessageToUser("Partner canceled download");
                    else
                        window.sendMessageToUser("Partner canceled upload");
                    setFilesToSend(null);
                    canceled = true;
                    sending = false;
                    receiving = false;
                }
                else if (message.Substring(0, 7).Equals("percent"))
                {
                    message = message.Substring(7);
                    String percent = message.Substring(0, message.IndexOf('*'));
                    String speed = message.Substring(message.IndexOf('*') + 1);
                    window.sendMessageToUser(percent + "% uploaded     " + speed + " KB/s");
                }
                else if (message.Substring(0, 8).Equals("failSend"))
                {
                    receiving = false;
                }
                else if (message.Substring(0, 10).Equals("sendOthers"))
                {
                    filesToSend.RemoveAt(0);
                    if (filesToSend.Count > 0)
                    {
                        String fileName = filesToSend.ElementAt(0).Substring(filesToSend.ElementAt(0).LastIndexOf("\\") + 1);
                        sendMessage("file" + fileName);
                    }
                    else
                    {
                        setFilesToSend(null);
                    }

                }
            }
        }

        public void sendMessage(String message)
        {
            try
            {
                sw.WriteLine(message);
                sw.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        public void disconnected()
        {
            receiving = false;
            sending = false;
            window.setConnectedText("Partner Disconnected");
            window.sendMessageToUser("Partner Disconnected");
            fileConnection.Close();
            messageConnection.Close();
            fileNS.Close();
            messageNS.Close();
        }

        public String receiveMessages()
        {

            try
            {
                String message = null;
                message = sr.ReadLine();
                return message;
            }
            catch (Exception e)
            {
                disconnected();
            }
            return null;
        }

        public void sendFile(String file)
        {
            successfulTransfer = false;
            canceled = false;
            sending = true;
            FileStream fs;
            try
            {
                fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException e)
            {
                window.sendMessageToUser("Unable to locate file: " + file);
                sendMessage("failSend");
                return;
            }
            window.sendMessageToUser("\nUploading file: " + file);
            byte[] buffer = new byte[8196];
            int bytesRead;
            long totalBytesSent = 0;
            BufferedStream bs = new BufferedStream(fileNS);
            try
            {
                while (sending && (bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bs.Write(buffer, 0, bytesRead);
                    bs.Flush();
                    totalBytesSent += bytesRead;
                }
            }
            catch (Exception e)
            {
                disconnected();
            }
            if (totalBytesSent == new FileInfo(file).Length)
                successfulTransfer = true;
            if (successfulTransfer)
                window.sendMessageToUser("Upload Complete");
            sending = false;
            fs.Close();
            bs.Flush();
        }

        public void updatePercentage()
        {
            waitHandle = new AutoResetEvent(false);
            double percentage;
            double speed = 0;
            int timePassed = 0;
            List<long> previousBytes = new List<long>();
            while (totalBytesRead < receiveFileSize && receiving)
            {
                percentage = Math.Round(((double)totalBytesRead / (double)receiveFileSize) * 100, 5);
                if (timePassed > 5)
                {
                    previousBytes.Add(totalBytesRead);
                    speed = ((totalBytesRead - previousBytes.ElementAt(previousBytes.Count - 6)) / 1024) / 5;
                    if (percentage > 0)
                        window.sendMessageToUser(percentage + "% downloaded     " + speed + " KB/s");
                    previousBytes.RemoveAt(0);
                }
                else if (timePassed > 0)
                {
                    previousBytes.Add(totalBytesRead);
                    speed = (totalBytesRead / 1024) / timePassed;
                    if (percentage > 0)
                        window.sendMessageToUser(percentage + "% downloaded     " + speed + " KB/s");
                }
                else
                {
                    previousBytes.Add(totalBytesRead);
                }
                if (percentage != 0)
                    sendMessage("percent" + percentage + "*" + speed);
                waitHandle.WaitOne(1000);
                timePassed++;
            }
            if (successfulTransfer)
                window.sendMessageToUser("Download Complete");
        }

        public String shortenFileSize(long sizeInBytes)
        {
            long gb = 10 * 1024 * 1024 * 1024L;
            long mb = 10 * 1024 * 1024L;
            long kb = 10 * 1024L;

            if (sizeInBytes > gb)
            {
                return sizeInBytes / 1024 / 1024 / 1024 + " GBs";
            }
            else if (sizeInBytes >= mb)
            {
                return sizeInBytes / 1024 / 1024 + " MBs";
            }
            else if (sizeInBytes >= kb)
            {
                return sizeInBytes / 1024 + " KBs";
            }
            else
            {
                return sizeInBytes + " Bytes";
            }
        }

        public void receiveFile()
        {
            canceled = false;
            successfulTransfer = false;
            receiving = true;
            window.sendMessageToUser("\nDownloading file: " + receiveFileLocation.Substring(receiveFileLocation.LastIndexOf("\\") + 1) + " | " + shortenFileSize(receiveFileSize));
            Thread updatePercentageThread = new Thread(new ThreadStart(updatePercentage));
            updatePercentageThread.IsBackground = true;
            updatePercentageThread.Start();
            FileStream fs = null;
            BufferedStream bs = new BufferedStream(fileNS);
            try
            {
                fs = new FileStream(receiveFileLocation, FileMode.Create, FileAccess.ReadWrite);
                byte[] buffer = new byte[8196];
                int bytesRead = 0;
                try
                {
                    sendMessage("oksend");
                    while (receiving && (bytesRead = bs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fs.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;

                        if (totalBytesRead == receiveFileSize)
                        {
                            successfulTransfer = true;
                            break;
                        }

                    }

                }
                catch (Exception e)
                {
                    disconnected();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed To Download: " + receiveFileLocation.Substring(receiveFileLocation.LastIndexOf("\\") + 1));
                sendMessage("fail");
            }
            receiving = false;
            waitHandle.Set();
            receiveFileSize = 0;
            totalBytesRead = 0;
            fileNS.Flush();
            try
            {
                fs.Close();
            }
            catch (Exception e)
            {

            }
            if (!successfulTransfer)
            {
                if (File.Exists(receiveFileLocation))
                    File.Delete(receiveFileLocation);
            }
            receiveFileLocation = null;
            if (!canceled)
                sendMessage("sendOthers");
        }

    }
}
