<?php

use App\Http\Controllers\ProfileController;
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

Route::get('/dashboard', function () {
    return view('dashboard');
})->middleware(['auth', 'verified'])->name('dashboard');

Route::middleware('auth')->group(function () {
    Route::get('/profile', [ProfileController::class, 'edit'])->name('profile.edit');
    Route::patch('/profile', [ProfileController::class, 'update'])->name('profile.update');
    Route::delete('/profile', [ProfileController::class, 'destroy'])->name('profile.destroy');
});

require __DIR__.'/auth.php';

Route::get('wsb', function(){
    return view('wsb', ['firstName' => 'Janusz', 'lastName' => 'Nowak']);
});

Route::get('/address/{city}/{street?}', function(string $city, string $street=null){
    if ($street != null)
        echo "Miasto: $city, ulica: $street";
    else
        echo "Miasto: $city, ulica: -";
});

Route::get('show_wsb', [\App\Http\Controllers\WsbController::class, 'index']);
Route::get('pages/{drive}', [\App\Http\Controllers\PageController::class, 'show']);

Route::view('userform', 'userform');
//Route::post('UserController', [\App\Http\Controllers\UserController::class, 'account']);
Route::get('UserController', [\App\Http\Controllers\UserController::class, 'account']);

//dokończyć błędy oraz tłumaczenie komunikatów walidacji na polskie komunikaty
