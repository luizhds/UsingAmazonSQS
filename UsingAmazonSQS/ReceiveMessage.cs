﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.SQS;
using System.Configuration;
using Amazon.SQS.Model;

namespace UsingAmazonSQS
{
    public class ReceiveMessage : AbstractInterpreter
    {

        public override string Description()
        {
            return "Receive a message";
        }

       
        public override void Execute(string[] args)
        {

            string QueueUrl = ConfigurationManager.AppSettings["SQSServiceQueeUrl"];
            string QueueName = ConfigurationManager.AppSettings["QueueName"];
            string QueueFullUrl = string.Concat(QueueUrl, QueueName);

            AmazonSQSClient sqs = new SQSConfig().Initialize();

            Console.Write(string.Format("Receive message from {0}", QueueName));

            ReceiveMessageRequest requestToReceive = new ReceiveMessageRequest(QueueFullUrl);           
            ReceiveMessageResponse response = sqs.ReceiveMessage(requestToReceive);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {

                Console.WriteLine();
                foreach (Amazon.SQS.Model.Message message in response.Messages)
                {

                    Console.WriteLine();
                    Console.WriteLine("Message Content");
                    Console.WriteLine(message.Body);
                    Console.WriteLine();

                    //delete message after peek it
                    sqs.DeleteMessage(new DeleteMessageRequest() { QueueUrl = QueueFullUrl, ReceiptHandle = message.ReceiptHandle });

                }

                Console.WriteLine();
                Console.WriteLine("Message has been receive!");
            }
            else
            {
                Console.WriteLine();
                Console.Write("Problems in the endpoint communication!");
            }

            Console.ReadKey();

        }

        
    }
}