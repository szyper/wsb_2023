<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class UserController extends Controller
{
    public function ShowUser(){
//      return DB::select('select * from users');
      //return DB::table('users')->get();

      /*return DB::table('users')
        ->select('name', 'email')
        ->get();*/

     /*return DB::table('users')
        ->select('name', 'email')
        ->where('name', '=', 'jan')
        ->get();*/

      /*return DB::table('users')
        ->where('name', '=', 'anna')
        ->update([
          'profile_photo_path' => '/public/photo/jan.jpeg'
        ]);*/

      return DB::table('cars')
        ->insert([
          'brand' => 'Fiat',
          'model' => '126p',
          'capacity' => 650
        ]);


    }
}
