using Asp.netKlinikDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public interface ITindakan : ICrud<Tindakan>
    {
        Task<IEnumerable<Tindakan>>DataTransaksi(int IdTransaksi);

        Task Transaksi_Selesai(Tindakan tindakan);

        //Task<IEnumerable<Tindakan>> get_Data_gigiRawat(int IdTransaksi);
    }
}
