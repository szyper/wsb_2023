<?php

use App\Http\Controllers\PageController;
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

/*
Route::get('address', function(){
  echo <<< ADDRESS
    Miasto:
ADDRESS;
});

Route::get('address1/{city}', function(string $city){
  echo <<< ADDRESS
    Miasto: $city
ADDRESS;
});

Route::get('address2/{city}/{street}', function(string $city, string $street){
  echo <<< ADDRESS
    Miasto: $city, ulica: $street
ADDRESS;
});

Route::get('address3/{city}/{street}/{zipCode}', function(string $city, string $street, int $zipCode){
  $zipCode = substr($zipCode, 0, 2).'-'.substr($zipCode, 2, 3);
  echo <<< ADDRESS
    Kod pocztowy: $zipCode<br>
    Miasto: $city, ulica: $street
ADDRESS;
});
*/

Route::get('address4/{city}/{street}/{zipCode?}', function(string $city, string $street, int $zipCode = null){

  $zipCode = (is_null($zipCode)) ? 'brak kodu pocztowego' : $zipCode = substr($zipCode, 0, 2).'-'.substr($zipCode, 2, 3);

  echo <<< ADDRESS
    Kod pocztowy: $zipCode<br>
    Miasto: $city, ulica: $street
ADDRESS;
})->name('data');

Route::redirect('adres/{city}/{street}/{zipCode?}', '/address4/{city}/{street}/{zipCode?}');

//Route::get('pages', [\App\Http\Controllers\PageController::class, 'show']);
Route::get('pages/{page}', [PageController::class, 'show']);

Route::view('userform', 'userform');
Route::post('FormController', [\App\Http\Controllers\FormController::class, 'showForm']);
//dokończyć walidację (polskie komunikaty o błędach)
