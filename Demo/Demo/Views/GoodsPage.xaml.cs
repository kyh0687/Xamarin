using Demo.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoodsPage : ContentPage
    {
        public ObservableCollection<Goods> Items { get; set; }

        public GoodsPage()
        {
            InitializeComponent();

            Title = "상품 리스트";

            Items = new ObservableCollection<Goods>();
            Items.Add(new Goods() { Id = 1, Image = "goods_1.png", Name = "단단한 돌파석", Description = "장비 재련에 사용되는 단단한 돌파석." });
            Items.Add(new Goods() { Id = 2, Image = "goods_2.png", Name = "부서진 돌파석", Description = "장비 재련에 사용되는 부서진 돌파석." });
            Items.Add(new Goods() { Id = 3, Image = "goods_3.png", Name = "태양석 파편 주머니", Description = "태양석 파편이 담겨 있는 주머니." });
            Items.Add(new Goods() { Id = 4, Image = "goods_4.png", Name = "용암의 숨결", Description = "뜨거운 용암의 힘을 품고 있다." });
            Items.Add(new Goods() { Id = 5, Image = "goods_5.png", Name = "대지의 숨결", Description = "희미한 대지의 힘을 품고 있다." });
            Items.Add(new Goods() { Id = 6, Image = "goods_1.png", Name = "단단한 돌파석", Description = "장비 재련에 사용되는 단단한 돌파석." });
            Items.Add(new Goods() { Id = 7, Image = "goods_2.png", Name = "부서진 돌파석", Description = "장비 재련에 사용되는 부서진 돌파석." });
            Items.Add(new Goods() { Id = 8, Image = "goods_3.png", Name = "태양석 파편 주머니", Description = "태양석 파편이 담겨 있는 주머니." });
            Items.Add(new Goods() { Id = 9, Image = "goods_4.png", Name = "용암의 숨결", Description = "뜨거운 용암의 힘을 품고 있다." });
            Items.Add(new Goods() { Id = 10, Image = "goods_5.png", Name = "대지의 숨결", Description = "희미한 대지의 힘을 품고 있다." });
            Items.Add(new Goods() { Id = 11, Image = "goods_1.png", Name = "단단한 돌파석", Description = "장비 재련에 사용되는 단단한 돌파석." });
            Items.Add(new Goods() { Id = 12, Image = "goods_2.png", Name = "부서진 돌파석", Description = "장비 재련에 사용되는 부서진 돌파석." });
            Items.Add(new Goods() { Id = 13, Image = "goods_3.png", Name = "태양석 파편 주머니", Description = "태양석 파편이 담겨 있는 주머니." });
            Items.Add(new Goods() { Id = 14, Image = "goods_4.png", Name = "용암의 숨결", Description = "뜨거운 용암의 힘을 품고 있다." });
            Items.Add(new Goods() { Id = 15, Image = "goods_5.png", Name = "대지의 숨결", Description = "희미한 대지의 힘을 품고 있다." });

            MyListView.ItemsSource = Items;

            // 구매데이터 초기화
            foreach (var item in Items)
            {
                App.PurchaseHistory.Add(new Purchase()
                {
                    Id = item.Id,
                    Name = item.Name,
                    TotalCount = 1
                });
            }

            SearchButton.Clicked += SearchButton_Clicked;
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            var text = SearchEntry.Text;

            if (string.IsNullOrEmpty(text))
            {
                MyListView.ItemsSource = Items;
            }
            else
            {
                MyListView.ItemsSource = Items.Where(x => x.Name.Contains(text));
                SearchEntry.Text = null;
            }
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var goods = e.Item as Goods;

            bool answer = await DisplayAlert("구매하시겠습니까?", goods.Name, "YES", "NO");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;

            if (answer.Equals(true))
            {
                App.PurchaseHistory.Where(t => t.Id == goods.Id).First().TotalCount++;
            }
        }
    }
}
