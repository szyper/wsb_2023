<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

class UsersController extends Controller
{
    public function Showdbtable(){
      $users = DB::table('users')->select('name', 'email', 'created_at')->get();
      return view('showdbtable', ['users' => $users]);
    }

    public function Adduser(Request $req){
//      return $req->input();
      $req->validate([
        'name' => 'required',
        'email' => 'required | same:email_confirmation',
        'pass' => 'required | same:pass_confirmation| regex:/(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])/',
      ]);

      $name = $req->input('name');
      $email = $req->input('email');
      $pass = Hash::make($req->input('pass'));
//
      $result = DB::insert('insert into users (name, email, password) values (?, ?, ?)', [$name, $email, $pass]);
//
      if ($result == 1){
        return 'Rekord dodany prawidłowo do tabeli users';
      }else{
        return 'Błąd dodania rekordu do tabeli users';
      }
    }
}
