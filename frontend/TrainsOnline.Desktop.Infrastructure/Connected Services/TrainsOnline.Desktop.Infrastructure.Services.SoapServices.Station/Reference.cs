﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;

namespace TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station
{


    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.IStationSoapEnd" +
        "pointService")]
    public interface IStationSoapEndpointService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "https://tempuri.org/IStationSoapEndpointService/CreateStation", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        System.Threading.Tasks.Task<TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.CreateStationResponse> CreateStationAsync(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.CreateStationRequest1 request);

        [System.ServiceModel.OperationContractAttribute(Action = "https://tempuri.org/IStationSoapEndpointService/GetStationDetails", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        System.Threading.Tasks.Task<TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationDetailsResponse1> GetStationDetailsAsync(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationDetailsRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "https://tempuri.org/IStationSoapEndpointService/UpdateStation", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        System.Threading.Tasks.Task<TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.UpdateStationResponse> UpdateStationAsync(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.UpdateStationRequest1 request);

        [System.ServiceModel.OperationContractAttribute(Action = "https://tempuri.org/IStationSoapEndpointService/DeleteStation", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        System.Threading.Tasks.Task<TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.DeleteStationResponse> DeleteStationAsync(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.DeleteStationRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "https://tempuri.org/IStationSoapEndpointService/GetStationsList", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        System.Threading.Tasks.Task<TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationsListResponse1> GetStationsListAsync(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationsListRequest request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class CreateStationRequest
    {

        private string nameField;

        private double latitudeField;

        private double longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public double Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public double Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class StationLookupModel
    {

        private string idField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Id
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class GetStationsListResponse
    {

        private List<StationLookupModel> stationsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 0)]
        public List<StationLookupModel> Stations
        {
            get
            {
                return this.stationsField;
            }
            set
            {
                this.stationsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class Unit
    {
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class UpdateStationRequest
    {

        private string idField;

        private string nameField;

        private double latitudeField;

        private double longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Id
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public double Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public double Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class RouteDeparturesToLookupModel
    {

        private string idField;

        private string nameField;

        private double latitudeField;

        private double longitudeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Id
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public double Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public double Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class RouteDeparturesLookupModel
    {

        private string idField;

        private RouteDeparturesToLookupModel toField;

        private System.DateTime departureTimeField;

        private string durationField;

        private double distanceField;

        private double ticketPriceField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Id
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public RouteDeparturesToLookupModel To
        {
            get
            {
                return this.toField;
            }
            set
            {
                this.toField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public System.DateTime DepartureTime
        {
            get
            {
                return this.departureTimeField;
            }
            set
            {
                this.departureTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "duration", Order = 3)]
        public string Duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        public double Distance
        {
            get
            {
                return this.distanceField;
            }
            set
            {
                this.distanceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public double TicketPrice
        {
            get
            {
                return this.ticketPriceField;
            }
            set
            {
                this.ticketPriceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class GetStationDetailsResponse
    {

        private string idField;

        private System.DateTime createdOnField;

        private string createdByField;

        private System.DateTime lastSavedOnField;

        private string lastSavedByField;

        private string nameField;

        private double latitudeField;

        private double longitudeField;

        private RouteDeparturesLookupModel departuresField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Id
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
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public System.DateTime CreatedOn
        {
            get
            {
                return this.createdOnField;
            }
            set
            {
                this.createdOnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string CreatedBy
        {
            get
            {
                return this.createdByField;
            }
            set
            {
                this.createdByField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public System.DateTime LastSavedOn
        {
            get
            {
                return this.lastSavedOnField;
            }
            set
            {
                this.lastSavedOnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public string LastSavedBy
        {
            get
            {
                return this.lastSavedByField;
            }
            set
            {
                this.lastSavedByField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        public double Latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public double Longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 8)]
        public RouteDeparturesLookupModel Departures
        {
            get
            {
                return this.departuresField;
            }
            set
            {
                this.departuresField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class IdRequest
    {

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Id
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
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class IdResponse
    {

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Id
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
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "CreateStation", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    public partial class CreateStationRequest1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.CreateStationRequest station;

        public CreateStationRequest1()
        {
        }

        public CreateStationRequest1(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.CreateStationRequest station)
        {
            this.station = station;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "CreateStationResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    public partial class CreateStationResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.IdResponse CreateStationResult;

        public CreateStationResponse()
        {
        }

        public CreateStationResponse(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.IdResponse CreateStationResult)
        {
            this.CreateStationResult = CreateStationResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetStationDetails", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    public partial class GetStationDetailsRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.IdRequest id;

        public GetStationDetailsRequest()
        {
        }

        public GetStationDetailsRequest(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.IdRequest id)
        {
            this.id = id;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetStationDetailsResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    public partial class GetStationDetailsResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationDetailsResponse GetStationDetailsResult;

        public GetStationDetailsResponse1()
        {
        }

        public GetStationDetailsResponse1(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationDetailsResponse GetStationDetailsResult)
        {
            this.GetStationDetailsResult = GetStationDetailsResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "UpdateStation", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    public partial class UpdateStationRequest1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.UpdateStationRequest station;

        public UpdateStationRequest1()
        {
        }

        public UpdateStationRequest1(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.UpdateStationRequest station)
        {
            this.station = station;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "UpdateStationResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    public partial class UpdateStationResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.Unit UpdateStationResult;

        public UpdateStationResponse()
        {
        }

        public UpdateStationResponse(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.Unit UpdateStationResult)
        {
            this.UpdateStationResult = UpdateStationResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteStation", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    public partial class DeleteStationRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.IdRequest id;

        public DeleteStationRequest()
        {
        }

        public DeleteStationRequest(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.IdRequest id)
        {
            this.id = id;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteStationResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    public partial class DeleteStationResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.Unit DeleteStationResult;

        public DeleteStationResponse()
        {
        }

        public DeleteStationResponse(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.Unit DeleteStationResult)
        {
            this.DeleteStationResult = DeleteStationResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetStationsList", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    public partial class GetStationsListRequest
    {

        public GetStationsListRequest()
        {
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetStationsListResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    public partial class GetStationsListResponse1
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationsListResponse GetStationsListResult;

        public GetStationsListResponse1()
        {
        }

        public GetStationsListResponse1(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationsListResponse GetStationsListResult)
        {
            this.GetStationsListResult = GetStationsListResult;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface IStationSoapEndpointServiceChannel : TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.IStationSoapEndpointService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class StationSoapEndpointServiceClient : System.ServiceModel.ClientBase<TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.IStationSoapEndpointService>, TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.IStationSoapEndpointService
    {

        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);

        public StationSoapEndpointServiceClient() :
                base(StationSoapEndpointServiceClient.GetDefaultBinding(), StationSoapEndpointServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpsBinding.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public StationSoapEndpointServiceClient(EndpointConfiguration endpointConfiguration) :
                base(StationSoapEndpointServiceClient.GetBindingForEndpoint(endpointConfiguration), StationSoapEndpointServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public StationSoapEndpointServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) :
                base(StationSoapEndpointServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public StationSoapEndpointServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) :
                base(StationSoapEndpointServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }

        public StationSoapEndpointServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public System.Threading.Tasks.Task<TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.CreateStationResponse> CreateStationAsync(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.CreateStationRequest1 request)
        {
            return base.Channel.CreateStationAsync(request);
        }

        public System.Threading.Tasks.Task<TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationDetailsResponse1> GetStationDetailsAsync(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationDetailsRequest request)
        {
            return base.Channel.GetStationDetailsAsync(request);
        }

        public System.Threading.Tasks.Task<TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.UpdateStationResponse> UpdateStationAsync(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.UpdateStationRequest1 request)
        {
            return base.Channel.UpdateStationAsync(request);
        }

        public System.Threading.Tasks.Task<TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.DeleteStationResponse> DeleteStationAsync(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.DeleteStationRequest request)
        {
            return base.Channel.DeleteStationAsync(request);
        }

        public System.Threading.Tasks.Task<TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationsListResponse1> GetStationsListAsync(TrainsOnline.Desktop.Infrastructure.Services.SoapServices.Station.GetStationsListRequest request)
        {
            return base.Channel.GetStationsListAsync(request);
        }

        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }

        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }

        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpsBinding))
            {
                System.ServiceModel.BasicHttpsBinding result = new System.ServiceModel.BasicHttpsBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }

        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpsBinding))
            {
                return new System.ServiceModel.EndpointAddress("https://genericapi.francecentral.cloudapp.azure.com/soap-api/station");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }

        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return StationSoapEndpointServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpsBinding);
        }

        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return StationSoapEndpointServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpsBinding);
        }

        public enum EndpointConfiguration
        {

            BasicHttpsBinding,
        }
    }
}
