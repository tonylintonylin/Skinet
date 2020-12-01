import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/shared/models/basket';
import { IOrder } from 'src/app/shared/models/order';
import { CheckoutService } from '../checkout.service';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss'],
})
export class CheckoutPaymentComponent implements OnInit {
  @Input() checkoutForm: FormGroup;

  constructor(
    private basketService: BasketService,
    private checkoutService: CheckoutService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  submitOrder(): void {
    const basket = this.basketService.getCurrentBasketValue();
    const orderToCreate = this.getOrderToCreate(basket);
    if (orderToCreate.deliveryMethodId !== 0) {
      this.checkoutService.createOrder(orderToCreate).subscribe(
        (order: IOrder) => {
          this.toastr.success('Order created succcesfully');
          this.basketService.deleteLocalBasket(basket.id);
          const navigationExtras: NavigationExtras = { state: order };
          this.router.navigate(['checkout/success'], navigationExtras);
        },
        (error) => {
          this.toastr.error(error.message);
          console.log(error);
        }
      );
    } else {
      this.toastr.error('Confirm your address and delivery method');
    }
  }

  private getOrderToCreate(
    basket: IBasket
  ): {
    basketId: string;
    deliveryMethodId: number;
    shipToAddress: any;
  } {
    return {
      basketId: basket.id,
      deliveryMethodId: +this.checkoutForm
        .get('deliveryForm')
        .get('deliveryMethod').value,
      shipToAddress: this.checkoutForm.get('addressForm').value,
    };
  }
}
