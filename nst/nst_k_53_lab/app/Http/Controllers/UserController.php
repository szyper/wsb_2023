<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class UserController extends Controller
{
    public function show(Request $req){
      $req->validate([
        'firstName' => 'required | min:3 |max:5',
        'email' => 'required | email',
      ]);
      //return $req->input();
//      return $req->input('email');
//      return $req->url();
//      return $req->method();
      return $req->path();
    }
}
