<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Faker\Factory as Faker;
use Illuminate\Support\Facades\DB;

class CreateFakeData extends Controller
{
    public function Show(){
      //$faker = Faker::create('pl_PL');
      $faker = Faker::create();
      $users = [];

      for ($i = 0; $i < 5; $i++){
        $name = $faker->firstName."_".$faker->lastName;
        $users[] = [
          'name' => $name,
//          'lastName' => $faker->lastName,
          'email' => $faker->email,
          'password' => bcrypt($faker->password),
          'created_at' => now(),
          'updated_at' => now()
        ];
      }

      //print_r($users[0]);

      DB::insert('insert into users (name, email, password, created_at, updated_at) values (?, ?, ?, ?, ?)', array_values($users[0]));

    }
}
