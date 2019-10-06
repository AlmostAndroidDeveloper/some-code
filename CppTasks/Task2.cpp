#include "pch.h"
#include <iostream>
using namespace std;
int *numbers_array;
int array_length = 0;

void print_inverted_array(int *inverted_array) {
	for (int i = 0;i < array_length;i++)
		cout << inverted_array[i] << " ";
}

int* invert_array() {
	int *result = new int[array_length];
	for (int i = 0;i < array_length;i++)
		result[array_length - i - 1] = numbers_array[i];
	return result;
}

int count_elements_with_less_right_neighbour_sum() {
	int sum = 0;
	for (int i = 0;i < array_length - 1;i++)
		if (numbers_array[i] > numbers_array[i + 1]) sum += numbers_array[i];
	return sum;
}

int count_submultiple_elements_sum() {
	int sum = 0;
	for (int i = 0;i < array_length;i++)
		if (numbers_array[i] % 2 == 0 || numbers_array[i] % 3 == 0)
			sum += numbers_array[i];
	return sum;
}

void print_main_array() {
	for (int i = 0;i < array_length;i++)
		cout << numbers_array[i] << " ";
	cout << endl;
}

void fill_array() {
	cout << "Введите длину массива:" << endl;
	cin >> array_length;
	numbers_array = new int[array_length];
	cout << "Введите элементы массива:" << endl;
	for (int i = 0;i < array_length;i++)
		cin >> numbers_array[i];
}

int main()
{
	setlocale(LC_ALL, "RUSSIAN");
	fill_array();
	//print_main_array();
	cout << "Сумма элементов делящихся на 2 или на 3: " << count_submultiple_elements_sum() << endl;
	cout << "Сумма элементов, больших чем правый сосед: " << count_elements_with_less_right_neighbour_sum() << endl;
	cout << "Инвертированный массив:" << endl;
	print_inverted_array(invert_array());
}
