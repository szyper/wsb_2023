<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;
use Faker\Factory as Faker;

class DbController extends Controller
{
    public function Show(){
      //return DB::select('select * from users');
      //return DB::table('users')->get();
      //return DB::table('users')->select('name', 'email')->get();

      /*return DB::table('users')
        ->select('name', 'email')
        ->get();*/

      /*return DB::table('users')
        ->select('name', 'email')
        ->where('name', '=', 'jan')
        ->get();*/

      /*return DB::table('users')
        ->where('name', '=', 'jan')
        ->update([
          'profile_photo_path' => 'jan.jpeg'
        ]);*/

      /*return DB::table('users')
        ->insert([
          'name' => 'Tomasz1',
          'email' => 'tomasz1@o2.pl',
          'password' => Hash::make('jan'),
        ]);*/

      $faker = Faker::create('pl_PL');
      //echo $faker->lastName;
      //echo $faker->firstName;

      //$users = [];
      for ($i = 0; $i < 10; $i++){
        $user = [
          'name' => $faker->firstName,
          'email' => $faker->email,
          'password' => Hash::make($faker->password),
          'created_at' => now(),
          'updated_at' => now(),
        ];

        DB::insert('insert into users (name, email, password, created_at, updated_at) values (?, ?, ?, ?, ?)', array_values($user));
      }

      //print_r($users);



    }
}
