﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication1.TemperatureConversionService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TemperatureConversionService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/convertFToC", ReplyAction="http://tempuri.org/IService1/convertFToCResponse")]
        int convertFToC(int fahrenheit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/convertFToC", ReplyAction="http://tempuri.org/IService1/convertFToCResponse")]
        System.Threading.Tasks.Task<int> convertFToCAsync(int fahrenheit);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/convertCToF", ReplyAction="http://tempuri.org/IService1/convertCToFResponse")]
        int convertCToF(int celsius);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/convertCToF", ReplyAction="http://tempuri.org/IService1/convertCToFResponse")]
        System.Threading.Tasks.Task<int> convertCToFAsync(int celsius);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WindowsFormsApplication1.TemperatureConversionService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WindowsFormsApplication1.TemperatureConversionService.IService1>, WindowsFormsApplication1.TemperatureConversionService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int convertFToC(int fahrenheit) {
            return base.Channel.convertFToC(fahrenheit);
        }
        
        public System.Threading.Tasks.Task<int> convertFToCAsync(int fahrenheit) {
            return base.Channel.convertFToCAsync(fahrenheit);
        }
        
        public int convertCToF(int celsius) {
            return base.Channel.convertCToF(celsius);
        }
        
        public System.Threading.Tasks.Task<int> convertCToFAsync(int celsius) {
            return base.Channel.convertCToFAsync(celsius);
        }
    }
}
