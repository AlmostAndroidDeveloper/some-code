#include "pch.h"
#include <iostream>
#include "Task1.h"
using namespace std;

int **matrix;
int rows = 0;
int columns = 0;

int find_left_to_right_diagonal(int column) {
	int sum = 0;
	for (int row = 0;row < rows;row++) {
		sum += matrix[row][column];
		column++;
		if (column >= columns) column = 0;
	}
	return sum;
}

int find_right_to_left_diagonal(int column) {
	int sum = 0;
	for (int row = 0;row < rows;row++) {
		sum += matrix[row][column];
		column--;
		if (column < 0) column = columns - 1;
	}
	return sum;
}

void delete_matrix() {
	for (int i = 0;i < rows;i++)
		delete[]matrix[i];
}

long multiply_all_diagonals() {
	long result = 1;
	for (int column = 0; column < columns; column++) {
		result *= find_left_to_right_diagonal(column);
		result *= find_right_to_left_diagonal(column);
	}
	return result;
}

void print_array() {
	for (int row = 0;row < rows;row++) {
		for (int column = 0; column < columns;column++)
			cout << matrix[row][column] << " ";
		cout << endl;
	}
}

void fill_array() {
	cout << "Введите количество строк матрицы:" << endl;
	cin >> rows;
	cout << "Введите количество столбцов матрицы:" << endl;
	cin >> columns;
	matrix = new int*[rows];
	for (int i = 0;i < rows;i++) {
		matrix[i] = new int[columns];
	}
	cout << "Введите элементы матрицы через пробел:" << endl;
	for (int i = 0;i < rows;i++) {
		for (int j = 0;j < columns;j++) {
			cin >> matrix[i][j];
		}
	}
}

int main()
{
	setlocale(LC_ALL, "RUSSIAN");
	fill_array();
	//print_array();
	cout << "Произведение сумм элементов диагоналей: " << multiply_all_diagonals();
	delete_matrix();
}




