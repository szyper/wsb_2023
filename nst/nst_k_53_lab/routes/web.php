<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\WsbController;

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

Route::get('wsb_show', [WsbController::class, 'show']);
//Route::get('wsb_show', [\App\Http\Controllers\WsbController::class, 'show']);

Route::get('pages/{drive}', [\App\Http\Controllers\PageController::class, 'show']);

Route::view('userform1', 'userform');
Route::post('UserController', [\App\Http\Controllers\UserController::class, 'show']);

Route::view('userform', 'forms.userform');
Route::post('UserController', [\App\Http\Controllers\FormController::class, 'showUser']);

