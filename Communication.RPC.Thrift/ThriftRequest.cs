/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Communication.RPC.Thrift
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class ThriftRequest : TBase
  {
    private string _RequestAddress;
    private string _Data;
    private string _Header;

    public string RequestAddress
    {
      get
      {
        return _RequestAddress;
      }
      set
      {
        __isset.RequestAddress = true;
        this._RequestAddress = value;
      }
    }

    public string Data
    {
      get
      {
        return _Data;
      }
      set
      {
        __isset.Data = true;
        this._Data = value;
      }
    }

    public string Header
    {
      get
      {
        return _Header;
      }
      set
      {
        __isset.Header = true;
        this._Header = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool RequestAddress;
      public bool Data;
      public bool Header;
    }

    public ThriftRequest() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                RequestAddress = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Data = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                Header = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("ThriftRequest");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (RequestAddress != null && __isset.RequestAddress) {
          field.Name = "RequestAddress";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(RequestAddress);
          oprot.WriteFieldEnd();
        }
        if (Data != null && __isset.Data) {
          field.Name = "Data";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Data);
          oprot.WriteFieldEnd();
        }
        if (Header != null && __isset.Header) {
          field.Name = "Header";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Header);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("ThriftRequest(");
      bool __first = true;
      if (RequestAddress != null && __isset.RequestAddress) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("RequestAddress: ");
        __sb.Append(RequestAddress);
      }
      if (Data != null && __isset.Data) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Data: ");
        __sb.Append(Data);
      }
      if (Header != null && __isset.Header) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Header: ");
        __sb.Append(Header);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
