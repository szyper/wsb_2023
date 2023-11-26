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

Route::post('add_article', [\App\Http\Controllers\ArticleController::class, 'AddArticle']);
Route::put('edit_article', [\App\Http\Controllers\ArticleController::class, 'EditArticle']);
Route::delete('delete_article', [\App\Http\Controllers\ArticleController::class, 'DeleteArticle']);
