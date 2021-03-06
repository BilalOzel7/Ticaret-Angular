import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/shared/models/basket';
import { IOrder, IOrderToCreate,} from 'src/app/shared/models/order';
import { CheckoutService } from '../checkout.service';

declare var Stripe: any;

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.css']
})
export class CheckoutPaymentComponent implements AfterViewInit {

@Input() checkoutForm: FormGroup;
@ViewChild('cardNumber',{static:true}) cardNumberElement: ElementRef;
@ViewChild('cardExpiry',{static:true}) cardExpiryElement: ElementRef;
@ViewChild('cardCvc',{static:true}) cardCvcElement: ElementRef;
stripe:any;
cardNumber:any;
cardExpiry:any;
cardCvc:any;
cardErrors:any;
cardHandler=this.onChange.bind(this);

  constructor(private basketService:BasketService, private checkoutService:CheckoutService,private toastr:ToastrService) { }
  
  ngAfterViewInit(): void {
    this.stripe=Stripe('pk_test_51Jr9Y0Dh1OJVJOotH2Duh7mCfoMYrelesXRRf8VLpL9wVN8HujH5ZvyHw43U3pT2oQCuOKPAiQben0WYFasXSINj00SdxsV6HN');
    const elements=this.stripe.elements();

    this.cardNumber=elements.create('cardNumber');
    this.cardNumber.mount(this.cardNumberElement.nativeElement);
    this.cardNumber.addEventListener('change',this.cardHandler)

    this.cardExpiry=elements.create('cardExpiry');
    this.cardExpiry.mount(this.cardExpiryElement.nativeElement);
    this.cardExpiry.addEventListener('change',this.cardHandler)

    this.cardCvc=elements.create('cardCvc');
    this.cardCvc.mount(this.cardCvcElement.nativeElement);
    this.cardCvc.addEventListener('change',this.cardHandler)
  }

  ngOnDestroy() {
    this.cardNumber.destroy();
    this.cardExpiry.destroy();
    this.cardCvc.destroy();
  }

  onChange({error}:any){
    if (error) {
      this.cardErrors=error.message;
    }else{
      this.cardErrors=null;
    }
  }

  submitOrder(){
    const basket=this.basketService.getCurrentBasketValue();
    const orderToCreate=this.getOrderToCreate(basket);
    this.checkoutService.createOrder(orderToCreate).subscribe((order:any)=>{
     
      this.stripe.confirmCardPayment(basket.clientSecret,{
        payment_method:{
          card:this.cardNumber,
          billing_details:{
            name:this.checkoutForm.get('paymentForm').get('nameOnCard').value
          }
        }
      }).then((result: { paymentIntent: any; })=>{
        console.log(result);
        if (result.paymentIntent) {
          this.basketService.deleteLocalBasket(basket.id);
          this.toastr.success('Order created successfully');
        }else{
          this.toastr.error('Payment error')
        }
      });
      console.log(order);
    },err => {
      this.toastr.error(err.message);
      console.log(err)
    });
  }

  getOrderToCreate(basket: IBasket) {
    return {
      basketId:basket.id,
      deliveryMethodId:+this.checkoutForm.get('deliveryForm').get('deliveryMethod').value,
      shipToAddress:this.checkoutForm.get('addressForm').value
    }
  }

  

}
