using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.ViewModels
{
    public class Purchase
    {
        /// <summary>
        /// 상품 이름
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 상품 이름
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 판매 수량
        /// </summary>
        public int TotalCount { get; set; }
    }
}
