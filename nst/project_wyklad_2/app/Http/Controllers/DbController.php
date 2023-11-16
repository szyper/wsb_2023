<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

class DbController extends Controller
{
    public function ShowUsers(){
//      return DB::select('select * from users');
//      return DB::table('users')->get();

//      return DB::table('users')
//      ->select('name', 'email', 'created_at')
//      ->get();

//      return DB::table('users')
//        ->select('name', 'email', 'created_at')
//        ->where('name', 'tomasz')
//        ->get();
      $pass = Hash::make('Tajne123');
      return DB::table('users')
        ->insert([
          'name' => 'Krystyna12',
          'email' => 'krystyna@o2.pl12',
          'password' => $pass,
          'created_at' => now(),
          'updated_at' => now(),
        ]);


    }
}
