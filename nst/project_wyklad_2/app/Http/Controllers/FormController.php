<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;
use Illuminate\Support\Facades\Hash;

class FormController extends Controller
{
    public function showForm(Request $req){
      $req->validate([
      'firstName' => 'required | min:2 | max:30',
      'lastName' => 'required | min:2 | max:50',
      'remail' => 'required | min:5 | max:50 | email | same:mail',
      ],
      [
        'firstName.required' => 'Pole :attribute jest wymagane',
        'firstName.min' => 'Pole :attribute musi mieć minimum :min znaki',
        'firstName.max' => 'Pole :attribute może mieć maksymalnie :max znaków',
        'lastName.required' => 'Pole :attribute jest wymagane',
        'lastName.min' => 'Pole :attribute musi mieć minimum :min znaki',
        'lastName.max' => 'Pole :attribute może mieć maksymalnie :max znaków',
        'mail.email' => 'Pole :attribute musi być adresem poczty elektronicznej',
        'remail.same' => 'Pole :attribute musi być identyczne jak pole :other',
      ]);
      //return $req->input();
      $user = [
        'firstName' => $req->input('firstName'),
        'lastName' => $req->input('lastName'),
        'mail' => $req->input('mail'),
      ];

      $name = $user['firstName'].'_'.$user['lastName'];
      $mail = $user['mail'];
      $pass = Hash::make('test');
      $now = now();
      DB::insert('insert into users (name, email, password, created_at, updated_at) values (?, ?, ?, ?, ?)', [$name, $mail, $pass, $now, $now]);

      return view('showuserform', ['user' => $user]);
    }
}
