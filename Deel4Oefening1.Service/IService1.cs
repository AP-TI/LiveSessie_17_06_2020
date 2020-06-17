using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Deel4Oefening1.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Speler> GetSpelers(string naam, DateTime geboorteDatum);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Deel4Oefening1.Service.ContractType".
    [DataContract]
    public class Speler
    {

        [DataMember]
        public int SpelersNr { get; set; }

        [DataMember]
        public string Naam { get; set; }

        [DataMember]
        public string Voorletters { get; set; }

        [DataMember]
        public DateTime Geb_Datum { get; set; }

        [DataMember]
        public char? Geslacht { get; set; }

        [DataMember]
        public int Jaartoe { get; set; }

        [DataMember]
        public string Straat { get; set; }

        [DataMember]
        public string HuisNr { get; set; }

        [DataMember]
        public string Postcode { get; set; }

        [DataMember]
        public string Plaats { get; set; }

        [DataMember]
        public string Telefoon { get; set; }

        [DataMember]
        public string BondsNr { get; set; }

    }
}
