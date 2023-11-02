<?php

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

Route::get('show_name', function (){
    return 'text';
});

Route::get('show_blade_city/{city}', function(string $city){
  return View('city', ['cityName' => $city]);
});

Route::get('/pages/{page}', function(string $page){
  $pages = [
    'home' => 'Strona domowa',
    'contact' => 'jan@o2.pl',
    'address' => 'Poznań, ul. Polna 10',
  ];
  return $pages[$page];
});

Route::get('/views/{view}', function(string $view){
  $views = [
    'city' => 'city',
    'name' => 'profile.name',
    'strona_glowna' => 'welcome',
  ];
  return View($views[$view]);
});

Route::get('/address/{city?}/{street?}/{zipCode?}', function(string $city = '-', string $street = '-', int $zipCode = null){
  $zipCode = substr($zipCode, 0, 2)."-".substr($zipCode, 2, 3);
  echo <<< ADDRESS
    Miasto: $zipCode; $city<br>
    Ulica: $street<hr>
ADDRESS;
})->name('address');

Route::redirect('/adres/{city?}/{street?}/{zipCode?}', '/address/{city?}/{street?}/{zipCode?}');

Route::prefix('admin')->group(function(){
  Route::get('/home', function(){
    return 'Strona domowa administratora';
  });

  Route::get('/users', function(){
    return 'Użytkownicy';
  });
});

Route::get('films', function(){
  $films = [
    'nameFilm1' => 'film1',
    'nameFilm2' => 'film2',
    'nameFilm3' => 'film3',
  ];
  return View('films', ['films' => $films]);
});

Route::get('users', function(){
  $users = [
    ['firstName' => 'Janusz', 'lastName' => 'Nowak', 'city' => 'Poznań'],
    ['firstName' => 'Anna', 'lastName' => 'Nowak', 'city' => 'Poznań'],
    ['firstName' => 'Paweł', 'lastName' => 'Nowak', 'city' => 'Gniezno'],
  ];
  return View('users', ['users' => $users]);
});


Route::get('car', [\App\Http\Controllers\CarController::class, 'ShowCarTable']);

Route::view('/addCar', 'forms.adduserform');

Route::get('AddCar', [\App\Http\Controllers\CarController::class, 'AddCar']);

Route::get('showdbtable', [\App\Http\Controllers\ShowDbTableController::class, 'ShowUsers']);

Route::get('showAddUserForm', function(){
  return view('forms.showAddUserForm');
});
Route::post('AddUserController', [\App\Http\Controllers\AddUserController::class, 'StroreUser']);
