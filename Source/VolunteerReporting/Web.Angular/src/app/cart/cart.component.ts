import { CartService } from './cart.service';
import { Component, OnInit } from '@angular/core';

import { GroceryItem } from './groceryitem';

@Component({
  selector: 'cbs-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
  availableItems: Array<GroceryItem> = new Array<GroceryItem>()

  constructor(private cartService: CartService) { }

  ngOnInit() {
    this.availableItems.push(
      { id: "3d2f3acf-869e-411f-9d09-d1722fd2ff60", image: "flask" },
      { id: "3c052b52-314a-4796-b81a-1a74c8452235", image: "cutlery" },
      { id: "76a53a35-f226-4b7a-9da1-f81eea27ebc1", image: "lemon-o" },
      { id: "28d8df01-98cf-4427-b4f3-63e11c007471", image: "paint-brush" }
    );
  }

  async addItem(item: GroceryItem) {
    console.log('Clicked item', item);
    await this.cartService.saveToCart(item);
  }
}
