import { AddItemToCart } from '../domain/addItemToCart';
import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import { GroceryItem } from './groceryitem';

@Injectable()
export class CartService {
  private headers = new Headers({ 'Content-Type': 'application/json' });

  constructor(private http: Http) { }

  saveToCart(item: GroceryItem): Promise<void> {
    const url = `http://localhost:5000/api/shopping/cart/items`;

    let addItemToCart = new AddItemToCart();
    addItemToCart.product = item.id;
    addItemToCart.quantity = 1;

    return this.http
      .post(url, JSON.stringify(addItemToCart), { headers: this.headers })
      .toPromise()
      .then(() => { console.log('success'); })
      .catch((error) => console.error(error));
  }
}