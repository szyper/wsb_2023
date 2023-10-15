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

Route::get('/pages/{page}', function($page){
    $pages = [
        'about' => 'Strona WSB',
        'contact' => 'wsb@poznan.pl',
        'home' => 'Strona domowa'
    ];
    return $pages[$page];
});

Route::get('address/{city?}/{street?}', function(string $city = '-', string $street = '-'){
   echo <<< ADDRESS
    Miasto: $city<br>
    Ulica: $street<br>
ADDRESS;
})->name('adres_wsb');

Route::redirect('/adres/{city?}/{street?}', '/address/{city?}/{street?}');

Route::get('wsbkontroler', [\App\Http\Controllers\WsbController::class, 'show']);

/*
Route::prefix('admin')->group(function () {
    Route::get('/users', function () {
        // Matches The "/admin/users" URL
    });
});
*/

Route::prefix('admin')->group(function(){
    Route::get('/users', function () {
        return 'Użytkownicy';
    });

    Route::get('/home', function () {
        return 'Strona domowa';
    });
});

Route::view('userform', 'forms.form_user');
Route::get('FormController', [\App\Http\Controllers\FormController::class, 'showForm']);
