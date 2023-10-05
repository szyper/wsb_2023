<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class PageController extends Controller
{
    public function show($drive){
        $pages = match($drive){
            'fdd' => 'dyskietka',
            'ssd' => 'dysk SSD',
            'hdd' => 'dysk HDD',
            default => 'Błędna wartość podana przez użytkownika'
        };
        return $pages;
    }
}
