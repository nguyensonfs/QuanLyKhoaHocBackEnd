using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoaHoc.Application.Payloads.ResponseModels.DataLoaiKhoaHoc
{
    public class DataResponseLoaiKhoaHoc : DataResponseBase
    {
        public string TenLoaiKhoaHoc { get; set; } = string.Empty;
    }
}
