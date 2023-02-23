﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSClient.ReviewsWS
{
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/")]
    public partial class Exception
    {
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/")]
    public partial class review
    {
        
        private string authorField;
        
        private string commentField;
        
        private System.DateTime dateField;
        
        private bool dateFieldSpecified;
        
        private long idField;
        
        private bool idFieldSpecified;
        
        private int ratingField;
        
        private string recipeIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public System.DateTime date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateSpecified
        {
            get
            {
                return this.dateFieldSpecified;
            }
            set
            {
                this.dateFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public long id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public int rating
        {
            get
            {
                return this.ratingField;
            }
            set
            {
                this.ratingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string recipeId
        {
            get
            {
                return this.recipeIdField;
            }
            set
            {
                this.recipeIdField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", ConfigurationName="WSClient.ReviewsWS.ReviewsDS")]
    public interface ReviewsDS
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://reviewsds.finalpractice.ws.miw.uniovi.es/ReviewsDS/getReviewsForRecipeRequ" +
            "est", ReplyAction="http://reviewsds.finalpractice.ws.miw.uniovi.es/ReviewsDS/getReviewsForRecipeResp" +
            "onse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<WSClient.ReviewsWS.getReviewsForRecipeResponse> getReviewsForRecipeAsync(WSClient.ReviewsWS.getReviewsForRecipeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://reviewsds.finalpractice.ws.miw.uniovi.es/ReviewsDS/createRecipeReviewReque" +
            "st", ReplyAction="http://reviewsds.finalpractice.ws.miw.uniovi.es/ReviewsDS/createRecipeReviewRespo" +
            "nse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WSClient.ReviewsWS.Exception), Action="http://reviewsds.finalpractice.ws.miw.uniovi.es/ReviewsDS/createRecipeReview/Faul" +
            "t/Exception", Name="Exception")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<WSClient.ReviewsWS.createRecipeReviewResponse> createRecipeReviewAsync(WSClient.ReviewsWS.createRecipeReviewRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://reviewsds.finalpractice.ws.miw.uniovi.es/ReviewsDS/deleteRecipeReviewReque" +
            "st", ReplyAction="http://reviewsds.finalpractice.ws.miw.uniovi.es/ReviewsDS/deleteRecipeReviewRespo" +
            "nse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WSClient.ReviewsWS.Exception), Action="http://reviewsds.finalpractice.ws.miw.uniovi.es/ReviewsDS/deleteRecipeReview/Faul" +
            "t/Exception", Name="Exception")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<WSClient.ReviewsWS.deleteRecipeReviewResponse> deleteRecipeReviewAsync(WSClient.ReviewsWS.deleteRecipeReviewRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://reviewsds.finalpractice.ws.miw.uniovi.es/ReviewsDS/getReviewByIdRequest", ReplyAction="http://reviewsds.finalpractice.ws.miw.uniovi.es/ReviewsDS/getReviewByIdResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<WSClient.ReviewsWS.getReviewByIdResponse> getReviewByIdAsync(WSClient.ReviewsWS.getReviewByIdRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getReviewsForRecipe", WrapperNamespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", IsWrapped=true)]
    public partial class getReviewsForRecipeRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        public getReviewsForRecipeRequest()
        {
        }
        
        public getReviewsForRecipeRequest(string arg0)
        {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getReviewsForRecipeResponse", WrapperNamespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", IsWrapped=true)]
    public partial class getReviewsForRecipeResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSClient.ReviewsWS.review[] @return;
        
        public getReviewsForRecipeResponse()
        {
        }
        
        public getReviewsForRecipeResponse(WSClient.ReviewsWS.review[] @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="createRecipeReview", WrapperNamespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", IsWrapped=true)]
    public partial class createRecipeReviewRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg0;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string arg2;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int arg3;
        
        public createRecipeReviewRequest()
        {
        }
        
        public createRecipeReviewRequest(string arg0, string arg1, string arg2, int arg3)
        {
            this.arg0 = arg0;
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.arg3 = arg3;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="createRecipeReviewResponse", WrapperNamespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", IsWrapped=true)]
    public partial class createRecipeReviewResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSClient.ReviewsWS.review @return;
        
        public createRecipeReviewResponse()
        {
        }
        
        public createRecipeReviewResponse(WSClient.ReviewsWS.review @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="deleteRecipeReview", WrapperNamespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", IsWrapped=true)]
    public partial class deleteRecipeReviewRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long arg0;
        
        public deleteRecipeReviewRequest()
        {
        }
        
        public deleteRecipeReviewRequest(long arg0)
        {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="deleteRecipeReviewResponse", WrapperNamespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", IsWrapped=true)]
    public partial class deleteRecipeReviewResponse
    {
        
        public deleteRecipeReviewResponse()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getReviewById", WrapperNamespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", IsWrapped=true)]
    public partial class getReviewByIdRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public long arg0;
        
        public getReviewByIdRequest()
        {
        }
        
        public getReviewByIdRequest(long arg0)
        {
            this.arg0 = arg0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getReviewByIdResponse", WrapperNamespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", IsWrapped=true)]
    public partial class getReviewByIdResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://reviewsds.finalpractice.ws.miw.uniovi.es/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public WSClient.ReviewsWS.review @return;
        
        public getReviewByIdResponse()
        {
        }
        
        public getReviewByIdResponse(WSClient.ReviewsWS.review @return)
        {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface ReviewsDSChannel : WSClient.ReviewsWS.ReviewsDS, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class ReviewsDSClient : System.ServiceModel.ClientBase<WSClient.ReviewsWS.ReviewsDS>, WSClient.ReviewsWS.ReviewsDS
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ReviewsDSClient() : 
                base(ReviewsDSClient.GetDefaultBinding(), ReviewsDSClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.ReviewsDSPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReviewsDSClient(EndpointConfiguration endpointConfiguration) : 
                base(ReviewsDSClient.GetBindingForEndpoint(endpointConfiguration), ReviewsDSClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReviewsDSClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ReviewsDSClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReviewsDSClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ReviewsDSClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ReviewsDSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WSClient.ReviewsWS.getReviewsForRecipeResponse> WSClient.ReviewsWS.ReviewsDS.getReviewsForRecipeAsync(WSClient.ReviewsWS.getReviewsForRecipeRequest request)
        {
            return base.Channel.getReviewsForRecipeAsync(request);
        }
        
        public System.Threading.Tasks.Task<WSClient.ReviewsWS.getReviewsForRecipeResponse> getReviewsForRecipeAsync(string arg0)
        {
            WSClient.ReviewsWS.getReviewsForRecipeRequest inValue = new WSClient.ReviewsWS.getReviewsForRecipeRequest();
            inValue.arg0 = arg0;
            return ((WSClient.ReviewsWS.ReviewsDS)(this)).getReviewsForRecipeAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WSClient.ReviewsWS.createRecipeReviewResponse> WSClient.ReviewsWS.ReviewsDS.createRecipeReviewAsync(WSClient.ReviewsWS.createRecipeReviewRequest request)
        {
            return base.Channel.createRecipeReviewAsync(request);
        }
        
        public System.Threading.Tasks.Task<WSClient.ReviewsWS.createRecipeReviewResponse> createRecipeReviewAsync(string arg0, string arg1, string arg2, int arg3)
        {
            WSClient.ReviewsWS.createRecipeReviewRequest inValue = new WSClient.ReviewsWS.createRecipeReviewRequest();
            inValue.arg0 = arg0;
            inValue.arg1 = arg1;
            inValue.arg2 = arg2;
            inValue.arg3 = arg3;
            return ((WSClient.ReviewsWS.ReviewsDS)(this)).createRecipeReviewAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WSClient.ReviewsWS.deleteRecipeReviewResponse> WSClient.ReviewsWS.ReviewsDS.deleteRecipeReviewAsync(WSClient.ReviewsWS.deleteRecipeReviewRequest request)
        {
            return base.Channel.deleteRecipeReviewAsync(request);
        }
        
        public System.Threading.Tasks.Task<WSClient.ReviewsWS.deleteRecipeReviewResponse> deleteRecipeReviewAsync(long arg0)
        {
            WSClient.ReviewsWS.deleteRecipeReviewRequest inValue = new WSClient.ReviewsWS.deleteRecipeReviewRequest();
            inValue.arg0 = arg0;
            return ((WSClient.ReviewsWS.ReviewsDS)(this)).deleteRecipeReviewAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WSClient.ReviewsWS.getReviewByIdResponse> WSClient.ReviewsWS.ReviewsDS.getReviewByIdAsync(WSClient.ReviewsWS.getReviewByIdRequest request)
        {
            return base.Channel.getReviewByIdAsync(request);
        }
        
        public System.Threading.Tasks.Task<WSClient.ReviewsWS.getReviewByIdResponse> getReviewByIdAsync(long arg0)
        {
            WSClient.ReviewsWS.getReviewByIdRequest inValue = new WSClient.ReviewsWS.getReviewByIdRequest();
            inValue.arg0 = arg0;
            return ((WSClient.ReviewsWS.ReviewsDS)(this)).getReviewByIdAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ReviewsDSPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.ReviewsDSPort))
            {
                return new System.ServiceModel.EndpointAddress("http://156.35.98.48:8080/ws.finalpractice.reviewsws/soapws/reviews");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ReviewsDSClient.GetBindingForEndpoint(EndpointConfiguration.ReviewsDSPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ReviewsDSClient.GetEndpointAddress(EndpointConfiguration.ReviewsDSPort);
        }
        
        public enum EndpointConfiguration
        {
            
            ReviewsDSPort,
        }
    }
}
