<?php

namespace App\Http\Controllers;

use App\Models\Products;
use Illuminate\Http\Request;

class ProductsController extends Controller
{
    public function AddProduct(Request $req)
    {

      $name = $req->name;
      $product = Products::where('name', $name)->first();

      if (!$product) {
        $product = new Products();
        $product->name = $req->name;
        $product->value = $req->value;
        $product->quantity = $req->quantity;
        $product->save();
      } else {
        return response()->json('Podana nazwa już istnieje');
      }
    }

  public function EditProduct(Request $req)
  {
      $product = Products::findorfail($req->id);

      //$product = new Products();
      $product->name = $req->name;
      $product->value = $req->value;
      $product->quantity = $req->quantity;
      $product->update();
  }

  public function DeleteProduct(Request $req)
  {
    $product = Products::findorfail($req->id)->delete();
    return 'Usunięcie rekordu';
  }
}

