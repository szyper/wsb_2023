<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\ShowController;

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
  return view('wsb', ['firstName' => 'Franek', 'lastName' => 'Nowak']);
});

Route::get('pages/{page}', function(string $page){
  $pages = [
    'about' => 'Informacje o stronie',
    'contact' => 'franek@gmail.com',
    'home' => 'Strona domowa'
  ];
  return $pages[$page]??"Błędne dane wprowadzone przez użytkownika!";
})->name('pages');

Route::get('/address/{city?}/{street?}/{postalCode?}', function(string $city = '-', string $street = '-', int $postalCode = null){
  $postalCode = is_null($postalCode) ? 'brak kodu pocztowego' : substr($postalCode, 0, 2).'-'.substr($postalCode, 2, 3);
  echo <<< SHOW
    Kod pocztowy: $postalCode<br>
    Miasto: $city<br>
    Ulica: $street<hr>
SHOW;
})->name('adres');

Route::redirect('adres/{city?}/{street?}/{postalCode?}', '/address/{city?}/{street?}/{postalCode?}');

Route::get('show', [\App\Http\Controllers\ShowController::class, 'show']);
Route::get('show_data', [ShowController::class, 'showData']);

Route::view('userform', 'forms.user_form');

Route::get('UserFormController', [\App\Http\Controllers\UserFormController::class, 'showForm']);

Route::get('car', [\App\Http\Controllers\CarController::class, 'ShowCarTable']);

Route::view('addUser', 'forms.adduserform');

Route::post('AddUser', [\App\Http\Controllers\CarController::class, 'AddUser']);
