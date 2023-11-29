<?php

use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider and all of them will
| be assigned to the "web" middleware group. Make something great!
|
*/

Route::get('/', function () {
    return view('welcome');
});

Route::middleware([
    'auth:sanctum',
    config('jetstream.auth_session'),
    'verified',
])->group(function () {
    Route::get('/dashboard', function () {
        return view('dashboard');
    })->name('dashboard');
});

Route::get('wsb', function(){
    return view('wsb', ['firstName' => 'Janusz', 'lastName' => 'Nowak']);
});

Route::get('wsb_kontroler', [\App\Http\Controllers\WsbController::class, 'show']);
Route::get('drives/{drive}', [\App\Http\Controllers\PageController::class, 'show']);

Route::view('userform', 'form');
//Route::get('UserController', [\App\Http\Controllers\UserController::class, 'show']);
Route::post('UserController', [\App\Http\Controllers\UserController::class, 'show']);

Route::get('show_db', [\App\Http\Controllers\DbController::class, 'show']);
Route::get('show_user', [\App\Http\Controllers\DbController::class, 'showUser']);

Route::get('add_product', [\App\Http\Controllers\ProductController::class, 'store']);
Route::get('update_product', [\App\Http\Controllers\ProductController::class, 'update']);
Route::get('delete_product', [\App\Http\Controllers\ProductController::class, 'destroy']);

Route::get('show_products', [\App\Http\Controllers\ProductController::class, 'index']);
