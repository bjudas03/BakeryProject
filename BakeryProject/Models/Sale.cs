using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BakeryProject.Models
{
    using System;
    using System.Collections.Generic;

    public class Sale
	{
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            this.SaleDetails = new HashSet<SaleDetail>();
        }

        public int SaleKey { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public Nullable<int> CustomerKey { get; set; }
        public Nullable<int> EmployeeKey { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Person Person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}