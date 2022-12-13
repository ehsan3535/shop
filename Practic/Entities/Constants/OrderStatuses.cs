using System.ComponentModel.DataAnnotations;

namespace Shop.Entities.Constants
{
    public enum OrderStatuses
    {
        Temp,
        [Display(Name = "در انتظار تایید")]
        WaitingForAccept,
        [Display(Name = "در انتظار پرداخت")]
        WaitingForPayment,
        [Display(Name = "در انتظار ارسال")]
        WaitingForSend,
        [Display(Name = "ارسال شده")]
        Sent,
        [Display(Name = "رد شده")]
        Declined,
        [Display(Name = "لغو شده")]
        Canceled
    }
}
