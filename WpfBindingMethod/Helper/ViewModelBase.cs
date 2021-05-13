using System.ComponentModel;

namespace System.Runtime.CompilerServices
{
    sealed class CallerMemberNameAttribute : Attribute { }
}

namespace SoraMVVM.Helper
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
//president 總裁.董事
//manager 負責人.主任.經理
//director    主管.署長; 局長.處長.主任
// supervisor  監督人.管理人.指導者
// leader  領導人
// receptionist    接待員;傳達員
// representative  代表,代理人
// porter  服務員
// secretary   秘書
// crew    全體船員.一組工作人員
// clerk   辦事員,職員.書記.記帳員
// colleague   同事.同僚.同行
//     顧問
// advisor 顧問
// counselor   顧問
// captain 船長
// staff   員工
// employee    員工
// worker  工人
// member  成員
// employer    老闆
// engineer    工程師
// attendant   服務員.侍者.出席者.參加者
// janitor 門警.看門人
// predecessor 前輩
// assistant   助理
// conductor   領導者.管理人.響導
// operator    操作者
// patron 贊助者.資助者
// advocate    提倡者
// sponsorship 資助者
// investor    投資者
// stockbroker 股票(或證券) 經紀人

