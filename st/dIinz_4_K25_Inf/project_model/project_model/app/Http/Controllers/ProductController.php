<?php

namespace App\Http\Controllers;

use App\Models\Product;
use Illuminate\Http\Request;

class ProductController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $products = Product::all();
        //return $products;
        return view('products.index', ['products'=>$products]);
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
    return view('products.create');
    }
    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        // $products = new Product();
        // $products->name = 'książka 1';
        // $products->price = 22.5;
        // $products->description = "opis ksiażki 1";
        // $products->save();

        $request->validate([
            'name' => 'required | min:3',
            'price' => 'required',
        ]);
        $products = new Product();
        $products->name = $request->name;
        $products->price = $request->price;
        $products->description = $request->description;
        $products->save();

    }

    /**
     * Display the specified resource.
     */
    public function show(Product $product)
    {
        return view('products.show', ['product' => $product]);
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(Product $product)
    {
        return 'edycja produktu';
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, Product $product)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Product $product)
    {
        //
    }
}
