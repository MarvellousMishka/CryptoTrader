//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LAP_PowerMining.Models.DatabaseModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Balance
    {
        public int id { get; set; }
        public System.DateTime created { get; set; }
        public int user_id { get; set; }
        public string currency { get; set; }
        public decimal amount { get; set; }
    
        public virtual User User { get; set; }
    }
}
