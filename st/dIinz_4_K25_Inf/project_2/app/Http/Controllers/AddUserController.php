<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

class AddUserController extends Controller
{
    public function StroreUser(Request $req){
      //return $req->input();
      $req->validate([
        'name' => 'required | min:2',
        'email' => 'required | min:5 | email | same:email_confirmation',
        'pass' => 'required | same:pass_confirmation|regex:/(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])/',
      ]);

      $name = $req->input('name');
      $pass = Hash::make($req->input('pass'));
      $email = $req->input('email');

      $result = DB::insert('insert into users (name, email, password) values (?, ?, ?)', [$name, $email, $pass]);

      if ($result == 1){
        return 'rekord dodany prawidłowo';
      }else{
        return 'error';
      }
    }
}
