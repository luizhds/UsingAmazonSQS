﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amazon.SQS;
using System.Configuration;
using Amazon.SQS.Model;

namespace UsingAmazonSQS
{
    public class SendMessage : AbstractInterpreter
    {

        public override string Description()
        {
            return "Send a sample message";
        }

        public override void Execute(string accessKey, string privateKey)
        {
           

        }

    }
}
