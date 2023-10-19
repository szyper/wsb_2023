<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class ShowController extends Controller
{
    public function show(){
      return 'Kontroler ShowController';
    }

    public function showData(){
        $data = [
          'firstName' => 'Anna',
          'lastName' => 'Nowak',
          'city' => 'Poznań',
          'hobby' => ['siatkówka', 'żużel', 'piłka ręczna']
        ];
//        return View('data', ['data' => $data]);
        return View('data', $data);
    }
}
