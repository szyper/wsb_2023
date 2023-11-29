<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;
use Faker\Factory;
use Illuminate\Support\Facades\DB;

class ProductSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    public function run(): void
    {
      $faker = Factory::create('pl_PL');

      for ($i = 0; $i < 10; $i++){
        $data = [
          'name' => $faker->sentence(1),
          'price' => $faker->randomFloat(2, 1, 100),
          'description' => $faker->paragraph(3),
          'created_at' => now(),
          'updated_at' => now()
        ];
        DB::table('products')->insert($data);
      }
    }
}
