<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "api" middleware group. Make something great!
|
*/

Route::middleware('auth:sanctum')->get('/user', function (Request $request) {
    return $request->user();
});

Route::get('testing', function(){
  return 'test';
});

Route::post('add_product', [\App\Http\Controllers\ProductsController::class, 'AddProduct']);
Route::put('edit_product', [\App\Http\Controllers\ProductsController::class, 'EditProduct']);
Route::delete('delete_product', [\App\Http\Controllers\ProductsController::class, 'DeleteProduct']);
