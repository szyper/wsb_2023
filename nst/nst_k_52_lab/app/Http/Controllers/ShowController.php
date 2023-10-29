<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class ShowController extends Controller
{
  public function ShowDb(){
    //return DB::select('select * from users');
    //return DB::table('users')->get();

    /*return DB::table('users')
      ->select('name', 'email')
      ->get();
    */

    /*return DB::table('users')
      ->select('name', 'email')
      ->where('name', '=', 'jan')
      ->get();*/

    return DB::table('users')
      ->where('name', '=', 'jan')
      ->update(
        [
          'profile_photo_path' => '/public/photo/jan.jpg'
        ]
      );



  }
}
