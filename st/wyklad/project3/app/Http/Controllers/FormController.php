<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class FormController extends Controller
{
    public function secondPage(Request $request)
    {
        $data = [
            'name' => $request->input('name'),
            'email' => $request->input('email')
        ];

        // Przypisanie wartości do zmiennych sesyjnych
        session(['name' => $request->input('name')]);
        session(['email' => $request->input('email')]);

        return view('/second-page', ['data' => $data]);
    }

// Kontroler dla trzeciej strony
    public function thirdPage()
    {
        // Pobranie wartości zmiennych sesyjnych
        session()->flush();

        $name = session('name');
        //session()->forget('email');
        $email = session('email');

        $email = session(['email' => $email ?? 'brak danych']);

        $email = session('email');

        // Wyświetlenie danych zmiennych sesyjnych
        return view('third-page', ['name' => $name, 'email' => $email, 'link' => '/third-page']);
    }
}
