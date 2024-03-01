using Kutuphane_Otomasyonu.Interfaces;
using Kutuphane_Otomasyonu.Model;
using Kutuphane_Otomasyonu.Model.Context;
using Kutuphane_Otomasyonu.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Otomasyonu.DAL
{
    public class EmanetKitaplarDAL:GenericRepository<KutuphaneContext,EmanetKitaplar>
    {
    }
}
