<?php

use App\Http\Controllers\PageController;
use Illuminate\Support\Facades\Route;

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

Route::get('address', function(){
    return 'test';
});

Route::get('address2/{city}/{street}/{zipCode}', function(string $city, string $street, int $zipCode){
    $zipCode = substr($zipCode,0,2).'-'.substr($zipCode, 2, 3);
    echo <<< ADDRESS
      Kod pocztowy: $zipCode<br>
      Miasto: $city, ulica: $street
ADDRESS;
});

Route::get('address3/{city?}/{street?}/{zipCode?}', function(string $city = '-', string $street = '', int $zipCode = null){
  $zipCode = (is_null($zipCode)) ? 'brak kodu pocztowego' : substr($zipCode,0,2).'-'.substr($zipCode, 2, 3);
  echo <<< ADDRESS
      Kod pocztowy: $zipCode<br>
      Miasto: $city, ulica: $street
ADDRESS;
})->name('adres_miasto');

Route::redirect('adres/{city?}/{street?}/{zipCode?}', '/address3/{city?}/{street?}/{zipCode?}');

Route::redirect('stronaglowna', '/');
Route::redirect('test', 'stronaglowna');

//Route::get('pages', [\App\Http\Controllers\PageController::class, 'show']);
Route::get('pages', [PageController::class, 'show']);
Route::get('drives/{drive}', [PageController::class, 'show']);

Route::view('userform', 'userform');
Route::post('UserController', [\App\Http\Controllers\UserController::class, 'showUser']);

Route::get('db', [\App\Http\Controllers\DbController::class, 'Show']);

Route::view('userform', 'forms.userform');
Route::get('AddUserController', [\App\Http\Controllers\AddUserController::class, 'AddUser']);
