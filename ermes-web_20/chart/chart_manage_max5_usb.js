var primo = 0;
var from_difference = 0;
var to_difference = 0;


//var data_chart = [[Date.UTC(2013, 1, 1, 08, 30), 2], [Date.UTC(2013, 2, 1, 10, 00), 3], [Date.UTC(2013, 3, 1, 16, 00), 2], [Date.UTC(2013, 3, 5, 16, 00), 2], [Date.UTC(2013, 4, 1, 16, 00), 2]];
var data_chart = [[Date.UTC(2013, 9, 12, 0, 30), 7.21], [Date.UTC(2013, 9, 12, 1, 0), 7.24], [Date.UTC(2013, 9, 12, 1, 30), 7.21], [Date.UTC(2013, 9, 12, 2, 0), 7.2], [Date.UTC(2013, 9, 12, 2, 30), 7.21], [Date.UTC(2013, 9, 12, 3, 0), 7.23], [Date.UTC(2013, 9, 12, 3, 30), 7.23], [Date.UTC(2013, 9, 12, 3, 31), 7.25], [Date.UTC(2013, 9, 12, 4, 1), 7.24], [Date.UTC(2013, 9, 12, 4, 31), 7.24], [Date.UTC(2013, 9, 12, 5, 1), 7.23], [Date.UTC(2013, 9, 12, 5, 31), 7.23], [Date.UTC(2013, 9, 12, 6, 1), 7.25], [Date.UTC(2013, 9, 12, 6, 31), 7.28], [Date.UTC(2013, 9, 12, 7, 2), 7.27], [Date.UTC(2013, 9, 12, 7, 32), 7.29], [Date.UTC(2013, 9, 12, 8, 2), 7.29], [Date.UTC(2013, 9, 12, 8, 32), 7.24], [Date.UTC(2013, 9, 12, 9, 2), 7.26], [Date.UTC(2013, 9, 12, 9, 32), 7.28], [Date.UTC(2013, 9, 12, 10, 2), 7.27], [Date.UTC(2013, 9, 12, 10, 33), 7.25], [Date.UTC(2013, 9, 12, 11, 3), 7.24], [Date.UTC(2013, 9, 12, 11, 33), 7.32], [Date.UTC(2013, 9, 12, 12, 3), 7.35], [Date.UTC(2013, 9, 12, 12, 33), 7.37], [Date.UTC(2013, 9, 12, 13, 3), 7.28], [Date.UTC(2013, 9, 12, 13, 34), 7.23], [Date.UTC(2013, 9, 12, 14, 4), 7.21], [Date.UTC(2013, 9, 12, 14, 34), 7.18], [Date.UTC(2013, 9, 12, 15, 4), 7.18], [Date.UTC(2013, 9, 12, 15, 34), 7.21], [Date.UTC(2013, 9, 12, 16, 4), 7.2], [Date.UTC(2013, 9, 12, 16, 34), 7.21], [Date.UTC(2013, 9, 12, 17, 5), 7.21], [Date.UTC(2013, 9, 12, 17, 35), 7.2], [Date.UTC(2013, 9, 12, 18, 1), 7.3], [Date.UTC(2013, 9, 12, 18, 5), 7.22], [Date.UTC(2013, 9, 12, 18, 35), 7.25], [Date.UTC(2013, 9, 12, 19, 5), 7.23], [Date.UTC(2013, 9, 12, 19, 35), 7.19], [Date.UTC(2013, 9, 12, 20, 5), 7.18], [Date.UTC(2013, 9, 12, 20, 36), 7.2], [Date.UTC(2013, 9, 12, 21, 6), 7.22], [Date.UTC(2013, 9, 12, 21, 36), 7.21], [Date.UTC(2013, 9, 12, 22, 2), 7.2], [Date.UTC(2013, 9, 12, 22, 6), 7.2], [Date.UTC(2013, 9, 12, 22, 36), 7.2], [Date.UTC(2013, 9, 12, 23, 6), 7.23], [Date.UTC(2013, 9, 12, 23, 36), 7.24], [Date.UTC(2013, 9, 13, 0, 0), 7.25], [Date.UTC(2013, 9, 13, 0, 30), 7.24], [Date.UTC(2013, 9, 13, 1, 0), 7.23], [Date.UTC(2013, 9, 13, 1, 30), 7.21], [Date.UTC(2013, 9, 13, 2, 0), 7.23], [Date.UTC(2013, 9, 13, 2, 30), 7.24], [Date.UTC(2013, 9, 13, 3, 0), 7.23], [Date.UTC(2013, 9, 13, 3, 31), 7.24], [Date.UTC(2013, 9, 13, 4, 1), 7.24], [Date.UTC(2013, 9, 13, 4, 30), 7.18], [Date.UTC(2013, 9, 13, 4, 31), 7.24], [Date.UTC(2013, 9, 13, 5, 1), 7.27], [Date.UTC(2013, 9, 13, 5, 31), 7.27], [Date.UTC(2013, 9, 13, 6, 1), 7.27], [Date.UTC(2013, 9, 13, 6, 31), 7.24], [Date.UTC(2013, 9, 13, 7, 2), 7.29], [Date.UTC(2013, 9, 13, 7, 32), 7.28], [Date.UTC(2013, 9, 13, 8, 2), 7.25], [Date.UTC(2013, 9, 13, 8, 32), 7.25], [Date.UTC(2013, 9, 13, 9, 2), 7.23], [Date.UTC(2013, 9, 13, 9, 32), 7.23], [Date.UTC(2013, 9, 13, 10, 2), 7.25], [Date.UTC(2013, 9, 13, 10, 33), 7.24], [Date.UTC(2013, 9, 13, 11, 3), 7.24], [Date.UTC(2013, 9, 13, 11, 33), 7.23], [Date.UTC(2013, 9, 13, 12, 3), 7.24], [Date.UTC(2013, 9, 13, 12, 33), 7.27], [Date.UTC(2013, 9, 13, 13, 3), 7.25], [Date.UTC(2013, 9, 13, 13, 34), 7.24], [Date.UTC(2013, 9, 13, 14, 4), 7.25], [Date.UTC(2013, 9, 13, 14, 34), 7.37], [Date.UTC(2013, 9, 13, 15, 4), 7.3], [Date.UTC(2013, 9, 13, 15, 34), 7.26], [Date.UTC(2013, 9, 13, 16, 1), 7.7], [Date.UTC(2013, 9, 13, 16, 4), 7.24], [Date.UTC(2013, 9, 13, 16, 34), 7.23], [Date.UTC(2013, 9, 13, 17, 5), 7.2], [Date.UTC(2013, 9, 13, 17, 35), 7.21], [Date.UTC(2013, 9, 13, 18, 5), 7.23], [Date.UTC(2013, 9, 13, 18, 35), 7.21], [Date.UTC(2013, 9, 13, 19, 5), 7.19], [Date.UTC(2013, 9, 13, 19, 35), 7.14], [Date.UTC(2013, 9, 13, 20, 6), 7.14], [Date.UTC(2013, 9, 13, 20, 36), 7.14], [Date.UTC(2013, 9, 13, 21, 1), 7.79], [Date.UTC(2013, 9, 13, 21, 6), 7.12], [Date.UTC(2013, 9, 13, 21, 36), 7.13], [Date.UTC(2013, 9, 13, 22, 1), 7.84], [Date.UTC(2013, 9, 13, 22, 6), 7.13], [Date.UTC(2013, 9, 13, 22, 31), 7.85], [Date.UTC(2013, 9, 13, 22, 36), 7.14], [Date.UTC(2013, 9, 13, 23, 6), 7.11], [Date.UTC(2013, 9, 13, 23, 37), 7.12], [Date.UTC(2013, 9, 14, 0, 0), 7.12], [Date.UTC(2013, 9, 14, 0, 30), 7.13], [Date.UTC(2013, 9, 14, 1, 0), 7.12], [Date.UTC(2013, 9, 14, 1, 30), 7.11], [Date.UTC(2013, 9, 14, 2, 0), 7.08], [Date.UTC(2013, 9, 14, 2, 30), 7.04], [Date.UTC(2013, 9, 14, 3, 0), 7.03], [Date.UTC(2013, 9, 14, 3, 31), 7.04], [Date.UTC(2013, 9, 14, 4, 1), 7.03], [Date.UTC(2013, 9, 14, 4, 31), 7.04], [Date.UTC(2013, 9, 14, 5, 1), 7.07], [Date.UTC(2013, 9, 14, 5, 31), 7.08], [Date.UTC(2013, 9, 14, 6, 1), 7.08], [Date.UTC(2013, 9, 14, 6, 31), 7.08], [Date.UTC(2013, 9, 14, 7, 2), 7.07], [Date.UTC(2013, 9, 14, 7, 32), 7.09], [Date.UTC(2013, 9, 14, 8, 2), 7.09], [Date.UTC(2013, 9, 14, 8, 32), 7.12], [Date.UTC(2013, 9, 14, 9, 2), 7.12], [Date.UTC(2013, 9, 14, 9, 32), 7.11], [Date.UTC(2013, 9, 14, 10, 3), 7.09], [Date.UTC(2013, 9, 14, 10, 33), 7.09], [Date.UTC(2013, 9, 14, 11, 3), 7.09], [Date.UTC(2013, 9, 14, 11, 33), 7.08], [Date.UTC(2013, 9, 14, 12, 3), 7.08], [Date.UTC(2013, 9, 14, 12, 33), 7.08], [Date.UTC(2013, 9, 14, 13, 3), 7.06], [Date.UTC(2013, 9, 14, 13, 30), 8.04], [Date.UTC(2013, 9, 14, 13, 34), 7.05], [Date.UTC(2013, 9, 14, 14, 0), 8.03], [Date.UTC(2013, 9, 14, 14, 4), 7.06], [Date.UTC(2013, 9, 14, 14, 34), 7.05], [Date.UTC(2013, 9, 14, 15, 4), 7.05], [Date.UTC(2013, 9, 14, 15, 34), 7.04], [Date.UTC(2013, 9, 14, 16, 4), 7.06], [Date.UTC(2013, 9, 14, 16, 34), 7.05], [Date.UTC(2013, 9, 14, 17, 5), 7.05], [Date.UTC(2013, 9, 14, 17, 35), 7.05], [Date.UTC(2013, 9, 14, 18, 5), 7.06], [Date.UTC(2013, 9, 14, 18, 35), 7.07], [Date.UTC(2013, 9, 14, 19, 5), 7.06], [Date.UTC(2013, 9, 14, 19, 35), 7.06], [Date.UTC(2013, 9, 14, 20, 6), 7.05], [Date.UTC(2013, 9, 14, 20, 36), 7.05], [Date.UTC(2013, 9, 14, 21, 6), 7.05], [Date.UTC(2013, 9, 14, 21, 36), 7.05], [Date.UTC(2013, 9, 14, 22, 6), 7.05], [Date.UTC(2013, 9, 14, 22, 36), 7.05], [Date.UTC(2013, 9, 14, 23, 6), 7.04], [Date.UTC(2013, 9, 14, 23, 37), 7.04], [Date.UTC(2013, 9, 15, 0, 0), 7.03], [Date.UTC(2013, 9, 15, 0, 30), 7.03], [Date.UTC(2013, 9, 15, 1, 0), 6.99], [Date.UTC(2013, 9, 15, 1, 30), 7], [Date.UTC(2013, 9, 15, 2, 0), 6.94], [Date.UTC(2013, 9, 15, 2, 30), 6.98], [Date.UTC(2013, 9, 15, 3, 0), 7], [Date.UTC(2013, 9, 15, 3, 30), 7.01], [Date.UTC(2013, 9, 15, 4, 1), 7], [Date.UTC(2013, 9, 15, 4, 31), 7], [Date.UTC(2013, 9, 15, 5, 1), 7.02], [Date.UTC(2013, 9, 15, 5, 31), 7.01], [Date.UTC(2013, 9, 15, 6, 1), 7], [Date.UTC(2013, 9, 15, 6, 30), 8.13], [Date.UTC(2013, 9, 15, 6, 31), 7.01], [Date.UTC(2013, 9, 15, 7, 1), 6.91], [Date.UTC(2013, 9, 15, 7, 32), 6.79], [Date.UTC(2013, 9, 15, 8, 2), 6.97], [Date.UTC(2013, 9, 15, 8, 32), 7.1], [Date.UTC(2013, 9, 15, 9, 2), 7.11], [Date.UTC(2013, 9, 15, 9, 32), 7.19], [Date.UTC(2013, 9, 15, 10, 2), 6.97], [Date.UTC(2013, 9, 15, 10, 32), 7.26], [Date.UTC(2013, 9, 15, 11, 3), 7.24], [Date.UTC(2013, 9, 15, 11, 33), 7.28], [Date.UTC(2013, 9, 15, 12, 3), 7.3], [Date.UTC(2013, 9, 15, 12, 33), 7.3], [Date.UTC(2013, 9, 15, 13, 3), 7.38], [Date.UTC(2013, 9, 15, 13, 31), 7.14], [Date.UTC(2013, 9, 15, 13, 33), 7.39], [Date.UTC(2013, 9, 15, 14, 3), 7.3], [Date.UTC(2013, 9, 15, 14, 34), 7.27], [Date.UTC(2013, 9, 15, 15, 4), 7.25], [Date.UTC(2013, 9, 15, 15, 34), 7.24], [Date.UTC(2013, 9, 15, 16, 4), 7.27], [Date.UTC(2013, 9, 15, 16, 34), 7.27], [Date.UTC(2013, 9, 15, 17, 4), 7.28], [Date.UTC(2013, 9, 15, 17, 34), 7.26], [Date.UTC(2013, 9, 15, 18, 5), 7.24], [Date.UTC(2013, 9, 15, 18, 35), 7.24], [Date.UTC(2013, 9, 15, 19, 1), 7.29], [Date.UTC(2013, 9, 15, 19, 5), 7.25], [Date.UTC(2013, 9, 15, 19, 35), 7.26], [Date.UTC(2013, 9, 15, 20, 5), 7.26], [Date.UTC(2013, 9, 15, 20, 31), 7.1], [Date.UTC(2013, 9, 15, 20, 35), 7.24], [Date.UTC(2013, 9, 15, 21, 6), 7.25], [Date.UTC(2013, 9, 15, 21, 36), 7.27], [Date.UTC(2013, 9, 15, 22, 6), 7.27], [Date.UTC(2013, 9, 15, 22, 36), 7.28], [Date.UTC(2013, 9, 15, 23, 6), 7.29], [Date.UTC(2013, 9, 15, 23, 36), 7.23], [Date.UTC(2013, 9, 16, 0, 0), 7.24], [Date.UTC(2013, 9, 16, 0, 30), 7.28], [Date.UTC(2013, 9, 16, 1, 0), 7.28], [Date.UTC(2013, 9, 16, 1, 30), 7.25], [Date.UTC(2013, 9, 16, 2, 0), 7.26], [Date.UTC(2013, 9, 16, 2, 30), 7.27], [Date.UTC(2013, 9, 16, 3, 0), 7.28], [Date.UTC(2013, 9, 16, 3, 31), 7.27], [Date.UTC(2013, 9, 16, 4, 1), 7.26], [Date.UTC(2013, 9, 16, 4, 31), 7.25], [Date.UTC(2013, 9, 16, 5, 1), 7.24], [Date.UTC(2013, 9, 16, 5, 31), 7.24], [Date.UTC(2013, 9, 16, 6, 1), 7.24], [Date.UTC(2013, 9, 16, 6, 31), 7.28], [Date.UTC(2013, 9, 16, 7, 2), 7.3], [Date.UTC(2013, 9, 16, 7, 32), 7.27], [Date.UTC(2013, 9, 16, 8, 2), 7.24], [Date.UTC(2013, 9, 16, 8, 32), 7.23], [Date.UTC(2013, 9, 16, 9, 2), 7.24], [Date.UTC(2013, 9, 16, 9, 32), 7.27], [Date.UTC(2013, 9, 16, 10, 3), 7.28], [Date.UTC(2013, 9, 16, 10, 33), 7.27], [Date.UTC(2013, 9, 16, 11, 3), 7.23], [Date.UTC(2013, 9, 16, 11, 33), 7.23], [Date.UTC(2013, 9, 16, 12, 3), 7.39], [Date.UTC(2013, 9, 16, 12, 33), 7.36], [Date.UTC(2013, 9, 16, 13, 3), 7.24], [Date.UTC(2013, 9, 16, 13, 34), 7.21], [Date.UTC(2013, 9, 16, 14, 1), 7.1], [Date.UTC(2013, 9, 16, 14, 4), 7.21], [Date.UTC(2013, 9, 16, 14, 34), 7.24], [Date.UTC(2013, 9, 16, 15, 1), 7.24], [Date.UTC(2013, 9, 16, 15, 4), 7.27], [Date.UTC(2013, 9, 16, 15, 34), 7.29], [Date.UTC(2013, 9, 16, 16, 4), 7.27], [Date.UTC(2013, 9, 16, 16, 35), 7.27], [Date.UTC(2013, 9, 16, 17, 5), 7.26], [Date.UTC(2013, 9, 16, 17, 35), 7.25], [Date.UTC(2013, 9, 16, 18, 5), 7.26], [Date.UTC(2013, 9, 16, 18, 35), 7.29], [Date.UTC(2013, 9, 16, 19, 5), 7.34], [Date.UTC(2013, 9, 16, 19, 35), 7.24], [Date.UTC(2013, 9, 16, 20, 6), 7.23], [Date.UTC(2013, 9, 16, 20, 36), 7.21], [Date.UTC(2013, 9, 16, 21, 6), 7.21], [Date.UTC(2013, 9, 16, 21, 36), 7.32], [Date.UTC(2013, 9, 16, 22, 6), 7.23], [Date.UTC(2013, 9, 16, 22, 36), 7.23], [Date.UTC(2013, 9, 16, 23, 6), 7.23], [Date.UTC(2013, 9, 16, 23, 37), 7.21], [Date.UTC(2013, 9, 17, 0, 0), 7.24], [Date.UTC(2013, 9, 17, 0, 30), 7.27], [Date.UTC(2013, 9, 17, 1, 0), 7.27], [Date.UTC(2013, 9, 17, 1, 30), 7.26], [Date.UTC(2013, 9, 17, 2, 0), 7.28], [Date.UTC(2013, 9, 17, 2, 30), 7.27], [Date.UTC(2013, 9, 17, 3, 0), 7.23], [Date.UTC(2013, 9, 17, 3, 31), 7.2], [Date.UTC(2013, 9, 17, 4, 1), 7.26], [Date.UTC(2013, 9, 17, 4, 31), 7.29], [Date.UTC(2013, 9, 17, 5, 1), 7.28], [Date.UTC(2013, 9, 17, 5, 31), 7.23], [Date.UTC(2013, 9, 17, 6, 1), 7.21], [Date.UTC(2013, 9, 17, 6, 31), 7.22], [Date.UTC(2013, 9, 17, 7, 2), 7.25], [Date.UTC(2013, 9, 17, 7, 32), 7.24], [Date.UTC(2013, 9, 17, 8, 2), 7.3], [Date.UTC(2013, 9, 17, 8, 32), 7.29], [Date.UTC(2013, 9, 17, 9, 2), 7.28], [Date.UTC(2013, 9, 17, 9, 32), 7.26], [Date.UTC(2013, 9, 17, 10, 2), 7.24], [Date.UTC(2013, 9, 17, 10, 33), 7.24], [Date.UTC(2013, 9, 17, 11, 3), 7.23], [Date.UTC(2013, 9, 17, 11, 33), 7.21], [Date.UTC(2013, 9, 17, 12, 3), 7.21], [Date.UTC(2013, 9, 17, 12, 33), 7.29], [Date.UTC(2013, 9, 17, 13, 3), 7.36], [Date.UTC(2013, 9, 17, 13, 34), 7.22], [Date.UTC(2013, 9, 17, 14, 4), 7.24], [Date.UTC(2013, 9, 17, 14, 34), 7.22], [Date.UTC(2013, 9, 17, 15, 1), 7.3], [Date.UTC(2013, 9, 17, 15, 4), 7.22], [Date.UTC(2013, 9, 17, 15, 34), 7.25], [Date.UTC(2013, 9, 17, 16, 4), 7.34], [Date.UTC(2013, 9, 17, 16, 34), 7.24], [Date.UTC(2013, 9, 17, 17, 5), 7.24], [Date.UTC(2013, 9, 17, 17, 35), 7.22], [Date.UTC(2013, 9, 17, 18, 5), 7.23], [Date.UTC(2013, 9, 17, 18, 35), 7.24], [Date.UTC(2013, 9, 17, 19, 5), 7.24], [Date.UTC(2013, 9, 17, 19, 35), 7.25], [Date.UTC(2013, 9, 17, 20, 5), 7.26], [Date.UTC(2013, 9, 17, 20, 36), 7.25], [Date.UTC(2013, 9, 17, 21, 6), 7.24], [Date.UTC(2013, 9, 17, 21, 36), 7.23], [Date.UTC(2013, 9, 17, 22, 6), 7.26], [Date.UTC(2013, 9, 17, 22, 36), 7.28], [Date.UTC(2013, 9, 17, 23, 6), 7.28], [Date.UTC(2013, 9, 17, 23, 36), 7.25], [Date.UTC(2013, 9, 18, 0, 0), 7.22], [Date.UTC(2013, 9, 18, 0, 30), 7.23], [Date.UTC(2013, 9, 18, 1, 0), 7.21], [Date.UTC(2013, 9, 18, 1, 30), 7.21], [Date.UTC(2013, 9, 18, 2, 0), 7.23], [Date.UTC(2013, 9, 18, 2, 30), 7.27], [Date.UTC(2013, 9, 18, 3, 0), 7.27], [Date.UTC(2013, 9, 18, 3, 31), 7.29], [Date.UTC(2013, 9, 18, 4, 1), 7.25], [Date.UTC(2013, 9, 18, 4, 31), 7.21], [Date.UTC(2013, 9, 18, 5, 1), 7.23], [Date.UTC(2013, 9, 18, 5, 31), 7.24], [Date.UTC(2013, 9, 18, 6, 1), 7.25], [Date.UTC(2013, 9, 18, 6, 31), 7.3], [Date.UTC(2013, 9, 18, 7, 2), 7.27], [Date.UTC(2013, 9, 18, 7, 32), 7.23], [Date.UTC(2013, 9, 18, 8, 0), 7.2], [Date.UTC(2013, 9, 18, 8, 2), 7.23], [Date.UTC(2013, 9, 18, 8, 32), 7.22], [Date.UTC(2013, 9, 18, 9, 2), 7.22], [Date.UTC(2013, 9, 18, 9, 32), 7.24], [Date.UTC(2013, 9, 18, 10, 2), 7.24], [Date.UTC(2013, 9, 18, 10, 33), 7.24], [Date.UTC(2013, 9, 18, 11, 1), 7.2], [Date.UTC(2013, 9, 18, 11, 3), 7.25], [Date.UTC(2013, 9, 18, 11, 33), 7.25], [Date.UTC(2013, 9, 18, 12, 3), 7.25], [Date.UTC(2013, 9, 18, 12, 33), 7.24], [Date.UTC(2013, 9, 18, 13, 3), 7.24], [Date.UTC(2013, 9, 18, 13, 33), 7.24], [Date.UTC(2013, 9, 18, 14, 4), 7.23], [Date.UTC(2013, 9, 18, 14, 34), 7.21], [Date.UTC(2013, 9, 18, 15, 4), 7.21], [Date.UTC(2013, 9, 18, 15, 34), 7.2], [Date.UTC(2013, 9, 18, 16, 4), 7.24], [Date.UTC(2013, 9, 18, 16, 34), 7.24], [Date.UTC(2013, 9, 18, 17, 5), 7.26], [Date.UTC(2013, 9, 18, 17, 35), 7.27], [Date.UTC(2013, 9, 18, 18, 5), 7.27], [Date.UTC(2013, 9, 18, 18, 35), 7.28], [Date.UTC(2013, 9, 18, 19, 5), 7.27], [Date.UTC(2013, 9, 18, 19, 35), 7.24], [Date.UTC(2013, 9, 18, 20, 5), 7.24], [Date.UTC(2013, 9, 18, 20, 36), 7.23], [Date.UTC(2013, 9, 18, 21, 6), 7.22], [Date.UTC(2013, 9, 18, 21, 36), 7.24], [Date.UTC(2013, 9, 18, 22, 6), 7.24], [Date.UTC(2013, 9, 18, 22, 36), 7.26], [Date.UTC(2013, 9, 18, 23, 6), 7.26], [Date.UTC(2013, 9, 18, 23, 36), 7.21], [Date.UTC(2013, 9, 19, 0, 0), 7.23], [Date.UTC(2013, 9, 19, 0, 30), 7.24], [Date.UTC(2013, 9, 19, 1, 0), 7.26], [Date.UTC(2013, 9, 19, 1, 30), 7.28], [Date.UTC(2013, 9, 19, 2, 0), 7.28], [Date.UTC(2013, 9, 19, 2, 30), 7.26], [Date.UTC(2013, 9, 19, 3, 0), 7.26], [Date.UTC(2013, 9, 19, 3, 30), 7.27], [Date.UTC(2013, 9, 19, 4, 1), 7.28], [Date.UTC(2013, 9, 19, 4, 31), 7.28], [Date.UTC(2013, 9, 19, 5, 1), 7.27], [Date.UTC(2013, 9, 19, 5, 31), 7.27], [Date.UTC(2013, 9, 19, 6, 1), 7.25], [Date.UTC(2013, 9, 19, 6, 31), 7.24], [Date.UTC(2013, 9, 19, 7, 1), 7.23], [Date.UTC(2013, 9, 19, 7, 32), 7.23], [Date.UTC(2013, 9, 19, 8, 0), 7.29], [Date.UTC(2013, 9, 19, 8, 2), 7.26], [Date.UTC(2013, 9, 19, 8, 30), 7.13], [Date.UTC(2013, 9, 19, 8, 32), 7.28], [Date.UTC(2013, 9, 19, 9, 2), 7.29], [Date.UTC(2013, 9, 19, 9, 32), 7.28], [Date.UTC(2013, 9, 19, 10, 2), 7.27], [Date.UTC(2013, 9, 19, 10, 32), 7.26], [Date.UTC(2013, 9, 19, 11, 3), 7.28], [Date.UTC(2013, 9, 19, 11, 33), 7.28], [Date.UTC(2013, 9, 19, 12, 3), 7.26], [Date.UTC(2013, 9, 19, 12, 33), 7.26], [Date.UTC(2013, 9, 19, 13, 3), 7.24], [Date.UTC(2013, 9, 19, 13, 33), 7.24], [Date.UTC(2013, 9, 19, 14, 3), 7.24], [Date.UTC(2013, 9, 19, 14, 31), 7.05], [Date.UTC(2013, 9, 19, 14, 34), 7.26], [Date.UTC(2013, 9, 19, 15, 4), 7.27], [Date.UTC(2013, 9, 19, 15, 34), 7.27], [Date.UTC(2013, 9, 19, 16, 4), 7.25], [Date.UTC(2013, 9, 19, 16, 34), 7.27], [Date.UTC(2013, 9, 19, 17, 4), 7.27], [Date.UTC(2013, 9, 19, 17, 34), 7.26], [Date.UTC(2013, 9, 19, 18, 5), 7.26], [Date.UTC(2013, 9, 19, 18, 35), 7.27], [Date.UTC(2013, 9, 19, 19, 5), 7.26], [Date.UTC(2013, 9, 19, 19, 35), 7.28], [Date.UTC(2013, 9, 19, 20, 1), 7.2], [Date.UTC(2013, 9, 19, 20, 5), 7.27], [Date.UTC(2013, 9, 19, 20, 35), 7.26], [Date.UTC(2013, 9, 19, 21, 6), 7.27], [Date.UTC(2013, 9, 19, 21, 31), 7.2], [Date.UTC(2013, 9, 19, 21, 36), 7.27], [Date.UTC(2013, 9, 19, 22, 6), 7.28], [Date.UTC(2013, 9, 19, 22, 36), 7.27], [Date.UTC(2013, 9, 19, 23, 6), 7.24], [Date.UTC(2013, 9, 19, 23, 36), 7.2], [Date.UTC(2013, 9, 20, 0, 0), 7.21], [Date.UTC(2013, 9, 20, 0, 30), 7.23], [Date.UTC(2013, 9, 20, 1, 0), 7.27], [Date.UTC(2013, 9, 20, 1, 30), 7.29], [Date.UTC(2013, 9, 20, 2, 0), 7.29], [Date.UTC(2013, 9, 20, 2, 30), 7.28], [Date.UTC(2013, 9, 20, 3, 0), 7.28], [Date.UTC(2013, 9, 20, 3, 31), 7.27], [Date.UTC(2013, 9, 20, 4, 1), 7.29], [Date.UTC(2013, 9, 20, 4, 30), 7.16], [Date.UTC(2013, 9, 20, 4, 31), 7.27], [Date.UTC(2013, 9, 20, 5, 1), 7.24], [Date.UTC(2013, 9, 20, 5, 30), 7.07], [Date.UTC(2013, 9, 20, 5, 31), 7.23], [Date.UTC(2013, 9, 20, 6, 1), 7.21], [Date.UTC(2013, 9, 20, 6, 30), 7.2], [Date.UTC(2013, 9, 20, 6, 31), 7.25], [Date.UTC(2013, 9, 20, 7, 0), 7.13], [Date.UTC(2013, 9, 20, 7, 2), 7.25], [Date.UTC(2013, 9, 20, 7, 32), 7.25], [Date.UTC(2013, 9, 20, 8, 2), 7.27], [Date.UTC(2013, 9, 20, 8, 32), 7.29], [Date.UTC(2013, 9, 20, 9, 2), 7.27], [Date.UTC(2013, 9, 20, 9, 32), 7.24], [Date.UTC(2013, 9, 20, 10, 3), 7.24], [Date.UTC(2013, 9, 20, 10, 30), 7.15], [Date.UTC(2013, 9, 20, 10, 33), 7.25], [Date.UTC(2013, 9, 20, 11, 3), 7.25], [Date.UTC(2013, 9, 20, 11, 33), 7.24], [Date.UTC(2013, 9, 20, 12, 3), 7.24], [Date.UTC(2013, 9, 20, 12, 33), 7.25], [Date.UTC(2013, 9, 20, 13, 3), 7.24], [Date.UTC(2013, 9, 20, 13, 34), 7.26], [Date.UTC(2013, 9, 20, 14, 4), 7.24], [Date.UTC(2013, 9, 20, 14, 34), 7.23], [Date.UTC(2013, 9, 20, 15, 4), 7.24], [Date.UTC(2013, 9, 20, 15, 34), 7.26], [Date.UTC(2013, 9, 20, 16, 4), 7.26], [Date.UTC(2013, 9, 20, 16, 35), 7.3], [Date.UTC(2013, 9, 20, 17, 5), 7.21], [Date.UTC(2013, 9, 20, 17, 31), 7.28], [Date.UTC(2013, 9, 20, 17, 35), 7.22], [Date.UTC(2013, 9, 20, 18, 5), 7.2], [Date.UTC(2013, 9, 20, 18, 35), 7.27], [Date.UTC(2013, 9, 20, 19, 5), 7.34], [Date.UTC(2013, 9, 20, 19, 35), 7.23], [Date.UTC(2013, 9, 20, 20, 6), 7.2], [Date.UTC(2013, 9, 20, 20, 36), 7.21], [Date.UTC(2013, 9, 20, 21, 6), 7.2], [Date.UTC(2013, 9, 20, 21, 36), 7.21], [Date.UTC(2013, 9, 20, 22, 6), 7.21], [Date.UTC(2013, 9, 20, 22, 36), 7.21], [Date.UTC(2013, 9, 20, 23, 6), 7.22], [Date.UTC(2013, 9, 20, 23, 37), 7.2], [Date.UTC(2013, 9, 21, 0, 0), 7.2], [Date.UTC(2013, 9, 21, 0, 30), 7.21], [Date.UTC(2013, 9, 21, 1, 0), 7.21], [Date.UTC(2013, 9, 21, 1, 30), 7.23], [Date.UTC(2013, 9, 21, 2, 0), 7.23], [Date.UTC(2013, 9, 21, 2, 30), 7.23], [Date.UTC(2013, 9, 21, 3, 0), 7.22], [Date.UTC(2013, 9, 21, 3, 31), 7.22], [Date.UTC(2013, 9, 21, 4, 1), 7.2], [Date.UTC(2013, 9, 21, 4, 31), 7.21], [Date.UTC(2013, 9, 21, 5, 0), 7.04], [Date.UTC(2013, 9, 21, 5, 1), 7.24], [Date.UTC(2013, 9, 21, 5, 31), 7.26], [Date.UTC(2013, 9, 21, 6, 1), 7.25], [Date.UTC(2013, 9, 21, 6, 31), 7.25], [Date.UTC(2013, 9, 21, 7, 2), 7.24], [Date.UTC(2013, 9, 21, 7, 32), 7.24], [Date.UTC(2013, 9, 21, 8, 2), 7.24], [Date.UTC(2013, 9, 21, 8, 32), 7.29], [Date.UTC(2013, 9, 21, 9, 2), 7.28], [Date.UTC(2013, 9, 21, 9, 32), 7.28], [Date.UTC(2013, 9, 21, 10, 3), 7.27], [Date.UTC(2013, 9, 21, 10, 33), 7.27], [Date.UTC(2013, 9, 21, 11, 3), 7.28], [Date.UTC(2013, 9, 21, 11, 33), 7.28], [Date.UTC(2013, 9, 21, 12, 3), 7.27], [Date.UTC(2013, 9, 21, 12, 33), 7.26], [Date.UTC(2013, 9, 21, 13, 3), 7.28], [Date.UTC(2013, 9, 21, 13, 34), 7.27], [Date.UTC(2013, 9, 21, 14, 4), 7.37], [Date.UTC(2013, 9, 21, 14, 34), 7.26], [Date.UTC(2013, 9, 21, 15, 4), 7.23], [Date.UTC(2013, 9, 21, 15, 34), 7.21], [Date.UTC(2013, 9, 21, 16, 4), 7.22], [Date.UTC(2013, 9, 21, 16, 35), 7.24], [Date.UTC(2013, 9, 21, 17, 5), 7.25], [Date.UTC(2013, 9, 21, 17, 35), 7.25], [Date.UTC(2013, 9, 21, 18, 5), 7.25], [Date.UTC(2013, 9, 21, 18, 35), 7.24], [Date.UTC(2013, 9, 21, 19, 5), 7.25], [Date.UTC(2013, 9, 21, 19, 35), 7.25], [Date.UTC(2013, 9, 21, 20, 6), 7.24], [Date.UTC(2013, 9, 21, 20, 36), 7.23], [Date.UTC(2013, 9, 21, 21, 6), 7.23], [Date.UTC(2013, 9, 21, 21, 36), 7.23], [Date.UTC(2013, 9, 21, 22, 6), 7.25], [Date.UTC(2013, 9, 21, 22, 36), 7.27], [Date.UTC(2013, 9, 21, 23, 6), 7.32], [Date.UTC(2013, 9, 21, 23, 37), 7.32], [Date.UTC(2013, 9, 22, 0, 0), 7.32], [Date.UTC(2013, 9, 22, 0, 30), 7.28], [Date.UTC(2013, 9, 22, 1, 0), 7.24], [Date.UTC(2013, 9, 22, 1, 30), 7.21], [Date.UTC(2013, 9, 22, 2, 0), 7.2], [Date.UTC(2013, 9, 22, 2, 30), 7.21], [Date.UTC(2013, 9, 22, 3, 0), 7.21], [Date.UTC(2013, 9, 22, 3, 31), 7.21], [Date.UTC(2013, 9, 22, 4, 1), 7.24], [Date.UTC(2013, 9, 22, 4, 31), 7.26], [Date.UTC(2013, 9, 22, 5, 1), 7.26], [Date.UTC(2013, 9, 22, 5, 31), 7.28], [Date.UTC(2013, 9, 22, 5, 59), 7.02], [Date.UTC(2013, 9, 22, 6, 1), 7.31], [Date.UTC(2013, 9, 22, 6, 31), 7.3], [Date.UTC(2013, 9, 22, 7, 2), 7.2], [Date.UTC(2013, 9, 22, 7, 32), 7.05], [Date.UTC(2013, 9, 22, 8, 0), 7.04], [Date.UTC(2013, 9, 22, 8, 2), 7.13], [Date.UTC(2013, 9, 22, 8, 32), 7.23], [Date.UTC(2013, 9, 22, 9, 2), 7.21], [Date.UTC(2013, 9, 22, 9, 32), 7.33], [Date.UTC(2013, 9, 22, 10, 0), 7.25], [Date.UTC(2013, 9, 22, 10, 3), 7.35], [Date.UTC(2013, 9, 22, 10, 33), 7.36], [Date.UTC(2013, 9, 22, 11, 3), 7.35], [Date.UTC(2013, 9, 22, 11, 33), 7.31], [Date.UTC(2013, 9, 22, 12, 3), 7.28], [Date.UTC(2013, 9, 22, 12, 33), 7.27], [Date.UTC(2013, 9, 22, 13, 3), 7.28], [Date.UTC(2013, 9, 22, 13, 34), 7.3], [Date.UTC(2013, 9, 22, 14, 4), 7.22], [Date.UTC(2013, 9, 22, 14, 34), 7.26], [Date.UTC(2013, 9, 22, 15, 4), 7.2], [Date.UTC(2013, 9, 22, 15, 34), 7.2], [Date.UTC(2013, 9, 22, 16, 4), 7.2], [Date.UTC(2013, 9, 22, 16, 35), 7.18], [Date.UTC(2013, 9, 22, 17, 5), 7.17], [Date.UTC(2013, 9, 22, 17, 35), 7.18], [Date.UTC(2013, 9, 22, 18, 5), 7.16], [Date.UTC(2013, 9, 22, 18, 35), 7.2], [Date.UTC(2013, 9, 22, 19, 5), 7.19], [Date.UTC(2013, 9, 22, 19, 35), 7.17], [Date.UTC(2013, 9, 22, 20, 6), 7.15], [Date.UTC(2013, 9, 22, 20, 36), 7.17], [Date.UTC(2013, 9, 22, 21, 6), 7.16], [Date.UTC(2013, 9, 22, 21, 36), 7.18], [Date.UTC(2013, 9, 22, 22, 6), 7.18], [Date.UTC(2013, 9, 22, 22, 36), 7.18], [Date.UTC(2013, 9, 22, 23, 6), 7.14], [Date.UTC(2013, 9, 22, 23, 37), 7.11], [Date.UTC(2013, 9, 23, 0, 0), 7.14], [Date.UTC(2013, 9, 23, 0, 30), 7.18], [Date.UTC(2013, 9, 23, 1, 0), 7.18], [Date.UTC(2013, 9, 23, 1, 30), 7.17], [Date.UTC(2013, 9, 23, 2, 0), 7.2], [Date.UTC(2013, 9, 23, 2, 30), 7.21], [Date.UTC(2013, 9, 23, 3, 0), 7.23], [Date.UTC(2013, 9, 23, 3, 31), 7.23], [Date.UTC(2013, 9, 23, 4, 1), 7.24], [Date.UTC(2013, 9, 23, 4, 31), 7.25], [Date.UTC(2013, 9, 23, 5, 1), 7.24], [Date.UTC(2013, 9, 23, 5, 31), 7.28], [Date.UTC(2013, 9, 23, 6, 1), 7.27], [Date.UTC(2013, 9, 23, 6, 31), 7.29], [Date.UTC(2013, 9, 23, 7, 2), 7.24], [Date.UTC(2013, 9, 23, 7, 32), 7.24], [Date.UTC(2013, 9, 23, 8, 2), 7.25], [Date.UTC(2013, 9, 23, 8, 32), 7.26], [Date.UTC(2013, 9, 23, 9, 2), 7.25], [Date.UTC(2013, 9, 23, 9, 30), 7.31], [Date.UTC(2013, 9, 23, 9, 32), 7.27], [Date.UTC(2013, 9, 23, 10, 3), 7.27], [Date.UTC(2013, 9, 23, 10, 33), 7.28], [Date.UTC(2013, 9, 23, 11, 3), 7.23], [Date.UTC(2013, 9, 23, 11, 33), 7.28], [Date.UTC(2013, 9, 23, 12, 3), 7.31], [Date.UTC(2013, 9, 23, 12, 33), 7.29], [Date.UTC(2013, 9, 23, 13, 3), 7.24], [Date.UTC(2013, 9, 23, 13, 34), 7.22], [Date.UTC(2013, 9, 23, 14, 4), 7.21], [Date.UTC(2013, 9, 23, 14, 34), 7.21], [Date.UTC(2013, 9, 23, 15, 4), 7.21], [Date.UTC(2013, 9, 23, 15, 34), 7.24], [Date.UTC(2013, 9, 23, 16, 4), 7.23], [Date.UTC(2013, 9, 23, 16, 35), 7.24], [Date.UTC(2013, 9, 23, 17, 5), 7.25], [Date.UTC(2013, 9, 23, 17, 35), 7.26], [Date.UTC(2013, 9, 23, 18, 5), 7.25], [Date.UTC(2013, 9, 23, 18, 35), 7.29], [Date.UTC(2013, 9, 23, 19, 5), 7.32], [Date.UTC(2013, 9, 23, 19, 35), 7.27], [Date.UTC(2013, 9, 23, 20, 6), 7.21], [Date.UTC(2013, 9, 23, 20, 36), 7.21], [Date.UTC(2013, 9, 23, 21, 6), 7.22], [Date.UTC(2013, 9, 23, 21, 36), 7.22], [Date.UTC(2013, 9, 23, 22, 6), 7.23], [Date.UTC(2013, 9, 23, 22, 36), 7.23], [Date.UTC(2013, 9, 23, 23, 6), 7.26], [Date.UTC(2013, 9, 23, 23, 37), 7.18], [Date.UTC(2013, 9, 24, 0, 0), 7.2], [Date.UTC(2013, 9, 24, 0, 30), 7.23], [Date.UTC(2013, 9, 24, 1, 0), 7.25], [Date.UTC(2013, 9, 24, 1, 30), 7.27], [Date.UTC(2013, 9, 24, 2, 0), 7.28], [Date.UTC(2013, 9, 24, 2, 30), 7.26], [Date.UTC(2013, 9, 24, 3, 0), 7.24], [Date.UTC(2013, 9, 24, 3, 31), 7.26], [Date.UTC(2013, 9, 24, 4, 1), 7.27], [Date.UTC(2013, 9, 24, 4, 31), 7.28], [Date.UTC(2013, 9, 24, 5, 0), 7.2], [Date.UTC(2013, 9, 24, 5, 1), 7.29], [Date.UTC(2013, 9, 24, 5, 31), 7.28], [Date.UTC(2013, 9, 24, 6, 1), 7.27], [Date.UTC(2013, 9, 24, 6, 31), 7.31], [Date.UTC(2013, 9, 24, 7, 2), 7.22], [Date.UTC(2013, 9, 24, 7, 32), 7.28], [Date.UTC(2013, 9, 24, 8, 2), 7.31], [Date.UTC(2013, 9, 24, 8, 32), 7.27], [Date.UTC(2013, 9, 24, 9, 0), 7.26], [Date.UTC(2013, 9, 24, 9, 2), 7.26], [Date.UTC(2013, 9, 24, 9, 32), 7.27], [Date.UTC(2013, 9, 24, 10, 3), 7.25], [Date.UTC(2013, 9, 24, 10, 33), 7.27], [Date.UTC(2013, 9, 24, 11, 3), 7.28], [Date.UTC(2013, 9, 24, 11, 33), 7.27], [Date.UTC(2013, 9, 24, 12, 3), 7.25], [Date.UTC(2013, 9, 24, 12, 33), 7.26], [Date.UTC(2013, 9, 24, 13, 3), 7.26], [Date.UTC(2013, 9, 24, 13, 34), 7.21], [Date.UTC(2013, 9, 24, 14, 4), 7.21], [Date.UTC(2013, 9, 24, 14, 34), 7.19], [Date.UTC(2013, 9, 24, 15, 4), 7.19], [Date.UTC(2013, 9, 24, 15, 34), 7.21], [Date.UTC(2013, 9, 24, 16, 4), 7.24], [Date.UTC(2013, 9, 24, 16, 35), 7.25], [Date.UTC(2013, 9, 24, 17, 5), 7.27], [Date.UTC(2013, 9, 24, 17, 35), 7.27], [Date.UTC(2013, 9, 24, 18, 5), 7.24], [Date.UTC(2013, 9, 24, 18, 35), 7.24], [Date.UTC(2013, 9, 24, 19, 5), 7.23], [Date.UTC(2013, 9, 24, 19, 35), 7.23], [Date.UTC(2013, 9, 24, 20, 6), 7.23], [Date.UTC(2013, 9, 24, 20, 36), 7.26], [Date.UTC(2013, 9, 24, 21, 6), 7.26], [Date.UTC(2013, 9, 24, 21, 36), 7.28], [Date.UTC(2013, 9, 24, 22, 6), 7.29], [Date.UTC(2013, 9, 24, 22, 36), 7.26], [Date.UTC(2013, 9, 24, 23, 7), 7.23], [Date.UTC(2013, 9, 24, 23, 37), 7.19], [Date.UTC(2013, 9, 25, 0, 0), 7.21], [Date.UTC(2013, 9, 25, 0, 30), 7.21], [Date.UTC(2013, 9, 25, 1, 0), 7.23], [Date.UTC(2013, 9, 25, 1, 30), 7.22], [Date.UTC(2013, 9, 25, 2, 0), 7.22], [Date.UTC(2013, 9, 25, 2, 30), 7.23], [Date.UTC(2013, 9, 25, 3, 0), 7.25], [Date.UTC(2013, 9, 25, 3, 31), 7.27], [Date.UTC(2013, 9, 25, 4, 1), 7.29], [Date.UTC(2013, 9, 25, 4, 31), 7.27], [Date.UTC(2013, 9, 25, 5, 1), 7.22], [Date.UTC(2013, 9, 25, 5, 31), 7.22], [Date.UTC(2013, 9, 25, 6, 1), 7.2], [Date.UTC(2013, 9, 25, 6, 31), 7.23], [Date.UTC(2013, 9, 25, 7, 2), 7.27], [Date.UTC(2013, 9, 25, 7, 32), 7.27], [Date.UTC(2013, 9, 25, 8, 2), 7.25], [Date.UTC(2013, 9, 25, 8, 32), 7.25], [Date.UTC(2013, 9, 25, 9, 2), 7.24], [Date.UTC(2013, 9, 25, 9, 32), 7.27], [Date.UTC(2013, 9, 25, 10, 3), 7.28], [Date.UTC(2013, 9, 25, 10, 33), 7.28], [Date.UTC(2013, 9, 25, 11, 3), 7.26], [Date.UTC(2013, 9, 25, 11, 33), 7.23], [Date.UTC(2013, 9, 25, 12, 3), 7.23], [Date.UTC(2013, 9, 25, 12, 33), 7.21], [Date.UTC(2013, 9, 25, 13, 3), 7.23], [Date.UTC(2013, 9, 25, 13, 34), 7.2], [Date.UTC(2013, 9, 25, 14, 4), 7.2], [Date.UTC(2013, 9, 25, 14, 34), 7.2], [Date.UTC(2013, 9, 25, 15, 4), 7.26], [Date.UTC(2013, 9, 25, 15, 34), 7.24], [Date.UTC(2013, 9, 25, 16, 4), 7.24], [Date.UTC(2013, 9, 25, 16, 35), 7.27], [Date.UTC(2013, 9, 25, 17, 5), 7.28], [Date.UTC(2013, 9, 25, 17, 35), 7.27], [Date.UTC(2013, 9, 25, 18, 5), 7.26], [Date.UTC(2013, 9, 25, 18, 35), 7.25], [Date.UTC(2013, 9, 25, 19, 5), 7.23], [Date.UTC(2013, 9, 25, 19, 35), 7.24], [Date.UTC(2013, 9, 25, 20, 6), 7.24], [Date.UTC(2013, 9, 25, 20, 36), 7.23], [Date.UTC(2013, 9, 25, 21, 6), 7.24], [Date.UTC(2013, 9, 25, 21, 36), 7.27], [Date.UTC(2013, 9, 25, 22, 6), 7.28], [Date.UTC(2013, 9, 25, 22, 36), 7.29], [Date.UTC(2013, 9, 25, 23, 6), 7.23], [Date.UTC(2013, 9, 25, 23, 37), 7.2], [Date.UTC(2013, 9, 26, 0, 0), 7.21], [Date.UTC(2013, 9, 26, 0, 30), 7.22], [Date.UTC(2013, 9, 26, 1, 0), 7.21], [Date.UTC(2013, 9, 26, 1, 30), 7.22], [Date.UTC(2013, 9, 26, 2, 0), 7.22], [Date.UTC(2013, 9, 26, 2, 30), 7.2], [Date.UTC(2013, 9, 26, 3, 0), 7.2], [Date.UTC(2013, 9, 26, 3, 31), 7.2], [Date.UTC(2013, 9, 26, 4, 1), 7.2], [Date.UTC(2013, 9, 26, 4, 31), 7.21], [Date.UTC(2013, 9, 26, 5, 1), 7.22], [Date.UTC(2013, 9, 26, 5, 31), 7.25], [Date.UTC(2013, 9, 26, 6, 1), 7.26], [Date.UTC(2013, 9, 26, 6, 31), 7.29], [Date.UTC(2013, 9, 26, 7, 2), 7.25], [Date.UTC(2013, 9, 26, 7, 32), 7.25], [Date.UTC(2013, 9, 26, 8, 2), 7.24], [Date.UTC(2013, 9, 26, 8, 32), 7.24], [Date.UTC(2013, 9, 26, 9, 2), 7.23], [Date.UTC(2013, 9, 26, 9, 32), 7.25], [Date.UTC(2013, 9, 26, 10, 3), 7.23], [Date.UTC(2013, 9, 26, 10, 33), 7.23], [Date.UTC(2013, 9, 26, 11, 3), 7.22], [Date.UTC(2013, 9, 26, 11, 33), 7.21], [Date.UTC(2013, 9, 26, 12, 3), 7.21], [Date.UTC(2013, 9, 26, 12, 33), 7.2], [Date.UTC(2013, 9, 26, 13, 3), 7.19], [Date.UTC(2013, 9, 26, 13, 34), 7.17], [Date.UTC(2013, 9, 26, 14, 4), 7.19], [Date.UTC(2013, 9, 26, 14, 34), 7.2], [Date.UTC(2013, 9, 26, 15, 4), 7.23], [Date.UTC(2013, 9, 26, 15, 34), 7.24], [Date.UTC(2013, 9, 26, 16, 4), 7.25]];

var data_chart1 = [[Date.UTC(2013, 1, 1, 08, 30), 0], [Date.UTC(2013, 2, 1, 10, 00), 0], [Date.UTC(2013, 3, 1, 16, 00), 1], [Date.UTC(2013, 3, 5, 16, 00), 1], [Date.UTC(2013, 4, 1, 16, 00), 0]];

var myFunction_log;

/*var data_chart1 = [{ x: Date.UTC(2013, 1, 1, 08, 30), y: 0 ,name: 'Off'},
    { x: Date.UTC(2013, 2, 1, 10, 00), y: 0, name: 'Off' },
    {x:Date.UTC(2013, 3, 1, 16, 00), y:1, name: 'ON'}, 
    { x: Date.UTC(2013, 3, 5, 16, 00), y: 1, name: 'ON' },
    { x: Date.UTC(2013, 4, 1, 16, 00), y: 0, name: 'off' }];*/


/*[{
name: 'pH',
id: 'dataseries',
data: data_chart,
marker: {
    enabled: true,
    radius: 3
},
tooltip: {
    valueDecimals: 2
}
},
        {
            type: 'flags',
            data: [{
                x: Date.UTC(2013, 2, 1, 10, 00),

                title: 'OFF',
                text: 'Power OFF'
            }, {
                x: Date.UTC(2013, 3, 1, 16, 00),

                title: 'OFF',
                text: 'Power OFF'
            }],
            color: '#5F86B3',
            fillColor: '#5F86B3',
            onSeries: 'dataseries',
            width: 22,
            style: {// text style
                color: 'white'
            },
            states: {
                hover: {
                    fillColor: '#395C84' // darker
                }
            }
        }];*/
var series_chart1 = [{
    type: 'column',
    name: 'Volume',
    data: data_chart1,
    yAxis: 1,

}];
/*[{
name: 'pH',
id: 'dataseries',
data: data_chart1,
marker: {
    enabled: true,
    radius: 3
},
yAxis: 1,
tooltip: {
    valueDecimals: 2
}
},
        {
            type: 'flags',
            data: [{
                x: Date.UTC(2013, 2, 1, 10, 00),

                title: 'OFF',
                text: 'Power OFF'
            }, {
                x: Date.UTC(2013, 3, 1, 16, 00),

                title: 'OFF',
                text: 'Power OFF'
            }],
            color: '#5F86B3',
            fillColor: '#5F86B3',
            onSeries: 'dataseries',
            width: 22,
            style: {// text style
                color: 'white'
            },
            states: {
                hover: {
                    fillColor: '#395C84' // darker
                }
            }
        }];*/




function salva_dati_log(callback) {
    myFunction_log = new Function(callback);
    myFunction_log();
}

function create_chart(dati, yAxis, plot_option) {
    
    $('#chart_div').highcharts('StockChart', {


        rangeSelector: {
            enabled: false
        },

        title: {
            text: graph_log
        },
        /*xAxis: {
            min: Date.UTC(data1.getFullYear(), data1.getMonth(), data1.getDate()),
            max: Date.UTC(data2.getFullYear(), data2.getMonth(), data2.getDate())
        },*/
        yAxis: yAxis,
        plotOptions: {
            scatter: {
                marker: {
                    radius: 1.2
                }
            }
        },
        series: dati
    }/*,
    function (chart) {

        // apply the date pickers
        setTimeout(function () {
            $('input.highcharts-range-selector', $(chart.container).parent())
                .datepicker({ dateFormat: 'dd/mm/yy' });
        }, 0)
    }*/);
    // Create the chart
   /* $.datepicker.setDefaults({
        //dateFormat: 'dd/mm/yy',
        onSelect: function (dateText) {

            primo = daydiff(parseDate($('#graph_log_from').val(), 'dd/mm/yy'), parseDate($('#graph_log_to').val(), 'dd/mm/yy'));
            from_difference = daydiff(parseDate($('#graph_log_from').val(), 'dd/mm/yy'), parseDate(init_date, 'dd/mm/yy'));
            to_difference = daydiff(parseDate($('#graph_log_to').val(), 'dd/mm/yy'), parseDate(last_date, 'dd/mm/yy'));
            /*  var secondo = daydiff(parseDate(last_date, 'dd/mm/yy'), parseDate(dateText, 'dd/mm/yy'));

               if ((primo <= 0) && (secondo <= 0)) {
                   
                   this.onchange();
                   this.onblur();
               }
               else {
                   if (primo < 0) {
                       last_date = dateText;
                       var differenza = daydiff(parseDate(init_date, 'dd/mm/yy'), parseDate(last_date, 'dd/mm/yy'));
                       if (differenza > 15) {
                           result_setpoint_change("Max 15gg");
                       }
                       else {
                           $("#refresh_log_server").trigger("click");
                       }
                   }
                   if (secondo < 0) {
                       init_date = dateText;
                      
                       var differenza = daydiff(parseDate(init_date, 'dd/mm/yy'), parseDate(last_date, 'dd/mm/yy'));
                       if (differenza > 15) {
                           result_setpoint_change("Max 15gg");
                       }
                       else {
                           $("#refresh_log_server").trigger("click");
                      }
                   }
               }*/

    /*    }
    });*/

}
function sort_array() {
    array_ch1.sort();
    array_ch2.sort();
    array_ch3.sort();
    array_ch4.sort();
    array_ch5.sort();
    array_aa1.sort();
    array_aa2.sort();
    array_aa3.sort();
    array_aa4.sort();
    array_aa5.sort();
    array_ab1.sort();
    array_ab2.sort();
    array_ab3.sort();
    array_ab4.sort();
    array_ab5.sort();
    array_ad1.sort();
    array_ad2.sort();
    array_ad3.sort();
    array_ad4.sort();
    array_ad5.sort();
    array_ar1.sort();
    array_ar2.sort();
    array_ar3.sort();
    array_ar4.sort();
    array_ar5.sort();
    array_flow.sort();
    array_temperatura.sort();

    data_report1 = init_date;
    data_report2 = last_date;

}

function create_picker() {
    $('#graph_log_from_max5').datepicker({
        dateFormat: 'dd/mm/yy'
    });
    $('#graph_log_to_max5').datepicker({
        dateFormat: 'dd/mm/yy'
    });
    $('#graph_log_from_max5').val(init_date);
    $('#graph_log_to_max5').val(last_date);

}
$("#refresh_log_server_max5").click(function () {
    salva_dati_log(0);
    // myFunction_log();

});

function parseDate(str, format) {
    //var mdy = str.split('/')
    var data = $.datepicker.parseDate(format, str);
    return data;
}
function get_action() {
    $("#form_log").attr("action", "chart/log_max5.aspx?init_date=" + init_date + "&last_date=" + last_date)
    return true;
}


function daydiff(first, second) {
    return (second - first) / (1000 * 60 * 60 * 24);
}
// Set the datepicker's date format
$("#refresh_graph_ld").click(function () {
    //alert("entro");
    var newdata1 = parseDate($('#graph_log_from_max5').val(), 'dd/mm/yy');
    var newdata2 = parseDate($('#graph_log_to_max5').val(), 'dd/mm/yy');
    from_difference = daydiff(newdata1, parseDate(init_date, 'dd/mm/yy'));
    to_difference = daydiff(newdata2, parseDate(last_date, 'dd/mm/yy'));

    if ((from_difference <= 0) && (to_difference >= 0)) {
        $("#log_collapse").hide();
        $('#chart_div').highcharts().destroy();
        //init_date = $('#graph_log_from').val();
        //last_date = $('#graph_log_to').val();
        var data1 = newdata1;
        var data2 = newdata2;
        data_report1 = $('#graph_log_from_max5').val();
        data_report2 = $('#graph_log_to_max5').val();

        upgrate_chart();
        if ((from_difference != 0) || (to_difference != 0)) {
            var chart_temp = $('#chart_div').highcharts();
            try {
                chart_temp.xAxis[0].setExtremes(
                     Date.UTC(data1.getFullYear(), data1.getMonth(), data1.getDate()),
                      Date.UTC(data2.getFullYear(), data2.getMonth(), data2.getDate()+1)
                    );
            }
            catch (ex) {

            }
        }
    }

    return false;
});





function upgrate_chart() {
    var altezza = 0;
    var numero_asse = 0;
    var counter_series = 0;
    var series_chart = [];
    var yaxis_chart = [];

    //canale ch1
    if (($('#ch1_val_max5').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_ch1,
            id: 'ch1_val_series',
            data: array_ch1,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
        yaxis_chart.push({
            title: {
                text: label_ch1
            },
            opposite: false,
            id: 'ch1_val',
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //-----------------------------------------------------------------------------------------------

    //-------------------------------------------------------------------------------------------------
    if (($('#ch1_aa').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch1_aa_label,
            id: 'ch2_val_series',
            data: array_aa1,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        },
        {
        id: 'flow_select_series1',
        name: ch1_aa_label,
        data: array_aa1,
        //type:'line',
        step: true,
        shadow: false,
        color: 'rgba(255,255,255,0.1)',
        tooltip: {
            //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
            // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
            pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
            
            valueDecimals: 0 
        },
        lineWidth: 2,
        shared: true,
        yAxis: numero_asse
    }  
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch1_aa_label
            },
            opposite: false,
            id: 'ch1_flow',
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch1_ab').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch1_ab_label,
            data: array_ab1,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch1_ab_label,
            data: array_ab1,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
             
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch1_ab_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch1_ad').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: ch1_ad_label,
            data: array_ad1,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch1_ad_label,
            data: array_ad1,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch1_ad_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch1_ar').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch1_ar_label,
            data: array_ar1,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        },
        
        {
            id: 'flow_select_series1',
            name: ch1_ar_label,
            data: array_ar1,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0 
            },
            lineWidth: 2,
            yAxis: numero_asse
        } 
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch1_ar_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //end  canale ch1
    //canale ch2
    if (($('#ch2_val_max5').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_ch2,
            id: 'ch6_val_series',
            data: array_ch2,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
        yaxis_chart.push({
            title: {
                text: label_ch2
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //-----------------------------------------------------------------------------------------------
    //digitale

    //-------------------------------------------------------------------------------------------------
    //allarmi
    if (($('#ch2_aa').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch2_aa_label,
            id: 'ch2_val_series',
            data: array_aa2,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch2_aa_label,
            data: array_aa2,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch2_aa_label
            },
            opposite: false,
            id: 'ch1_flow',
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch2_ab').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch2_ab_label,
            data: array_ab2,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch2_ab_label,
            data: array_ab2,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch2_ab_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch2_ad').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: ch2_ad_label,
            data: array_ad2,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch2_ad_label,
            data: array_ad2,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch2_ad_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch2_ar').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch2_ar_label,
            data: array_ar2,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch2_ar_label,
            data: array_ar2,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch2_ar_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //end  canale ch2
    //canale ch3
    if (($('#ch3_val_max5').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_ch3,
            id: 'ch6_val_series',
            data: array_ch3,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
        yaxis_chart.push({
            title: {
                text: label_ch3
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //-----------------------------------------------------------------------------------------------
    //digitale
 
    //-------------------------------------------------------------------------------------------------
    //allarmi
    if (($('#ch3_aa').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch3_aa_label,
            id: 'ch2_val_series',
            data: array_aa3,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch3_aa_label,
            data: array_aa3,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch3_aa_label
            },
            opposite: false,
            id: 'ch1_flow',
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch3_ab').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch3_ab_label,
            data: array_ab3,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch3_ab_label,
            data: array_ab3,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch3_ab_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch3_ad').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: ch3_ad_label,
            data: array_ad3,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch3_ad_label,
            data: array_ad3,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch3_ad_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch3_ar').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch3_ar_label,
            data: array_ar3,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch3_ar_label,
            data: array_ar3,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch3_ar_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //end  canale ch3
    //canale ch4
    if (($('#ch4_val_max5').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_ch4,
            id: 'ch6_val_series',
            data: array_ch4,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
        yaxis_chart.push({
            title: {
                text: label_ch4
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //-----------------------------------------------------------------------------------------------
    //digitale

    //-------------------------------------------------------------------------------------------------
    //allarmi
    if (($('#ch4_aa').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch4_aa_label,
            id: 'ch2_val_series',
            data: array_aa4,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch4_aa_label,
            data: array_aa4,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch4_aa_label
            },
            opposite: false,
            id: 'ch1_flow',
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch4_ab').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch4_ab_label,
            data: array_ab4,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch4_ab_label,
            data: array_ab4,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch4_ab_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });

        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch4_ad').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: ch4_ad_label,
            data: array_ad4,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch4_ad_label,
            data: array_ad4,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch4_ad_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch4_ar').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch4_ar_label,
            data: array_ar4,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch4_ar_label,
            data: array_ar4,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch4_ar_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //end  canale ch4
    //canale ch5
    if (($('#ch5_val_max5').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: label_ch5,
            id: 'ch6_val_series',
            data: array_ch5,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
        yaxis_chart.push({
            title: {
                text: label_ch5
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //-----------------------------------------------------------------------------------------------
    //digitale
 
    //-------------------------------------------------------------------------------------------------
    if (($('#ch5_aa').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            name: ch5_aa_label,
            id: 'ch2_val_series',
            data: array_aa5,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch5_aa_label,
            data: array_aa5,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch5_aa_label
            },
            opposite: false,
            id: 'ch1_flow',
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch5_ab').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch3_val_series',
            name: ch5_ab_label,
            data: array_ab5,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch5_ab_label,
            data: array_ab5,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch5_ab_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch5_ad').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch4_val_series',
            name: ch5_ad_label,
            data: array_ad5,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch5_ad_label,
            data: array_ad5,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch5_ad_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    if (($('#ch5_ar').is(':checked')) && (counter_series < 10)) {
        series_chart.push({
            id: 'ch5_val_series',
            name: ch5_ar_label,
            data: array_ar5,
            step: true,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        ,
        {
            id: 'flow_select_series1',
            name: ch5_ar_label,
            data: array_ar5,
            //type:'line',
            step: true,
            shadow: false,
            color: 'rgba(255,255,255,0.1)',
            tooltip: {
                //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
                pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
                valueDecimals: 0
            },
            lineWidth: 2,
            yAxis: numero_asse
        }
        );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: ch5_ar_label
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });
        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    //end  canale ch5
    //TEMPERATURA
    if (($('#temperature_max5').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: temperature_label,
            id: 'ch6_val_series',
            data: array_temperatura,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
        yaxis_chart.push({
            title: {
                text: temperature_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });

        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }



    if (($('#flow_meter').is(':checked')) && (counter_series < 10)) {

        series_chart.push({
            name: "Flow Meter",
            id: 'ch6_val_series',
            data: array_wm,
            yAxis: numero_asse,
            marker: {
                enabled: true,
                radius: 3
            },
            tooltip: {
                valueDecimals: 2
            }
        });
        yaxis_chart.push({
            title: {
                text: flow_meter_label
            },
            opposite: false,
            id: 'ch1_val',
            top: altezza,
            height: 200,
            lineWidth: 2
        });
        altezza = altezza + 300;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }

    if (($('#flow_meter_max5').is(':checked')) && (counter_series < 10)) {
    
        series_chart.push({
            id: 'flow_select_series',
            name: label_flow_select,
            data: array_flow,
            type: 'scatter',
            tooltip: {
                pointFormat: function () {
                    return false;
                },
                valueDecimals: 0
            },

            step: true,

            lineWidth: 2,
            yAxis: numero_asse/*,
            formatter: function () {
                colore = this.series.color;
            }*/
        },
{
    id: 'flow_select_series1',
    name: label_flow_select,
    data: array_flow,
    //type:'line',
    step: true,
    shadow: false,
    color: 'rgba(255,255,255,0.1)',
    tooltip: {
        //pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
       // formatter: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span>',
        pointFormat: '<span style="#FFFFF">{series.name}:<b>{point.y}</b></span><br/>',
        valueDecimals: 0 
    },
    lineWidth: 2,
    yAxis: numero_asse
}   );
        yaxis_chart.push({
            labels: {
                formatter: function () {
                    if (this.value == 1) {
                        return 'ON';
                    }
                    else {
                        return 'OFF';
                    }
                }
            },

            title: {
                text: label_flow_select
            },
            opposite: false,
            top: altezza,
            height: 100,
            offset: 0,
            lineWidth: 2,
            max: 2,
            min: 0
        });

        altezza = altezza + 150;
        numero_asse = numero_asse + 1;
        counter_series = counter_series + 1;
    }
    altezza = altezza + 100;

    // series_chart[0].setData(array_ch1);
    // series_chart[1].setData(array_ch1);
    $("#chart_div").height(altezza);
    create_chart(series_chart, yaxis_chart);
    draw_tabella();
}
function convertUTCDateToLocalDate(convertdLocalTime)
    {
    

        var hourOffset = convertdLocalTime.getTimezoneOffset() / 60;

        convertdLocalTime.setHours( convertdLocalTime.getHours() + hourOffset ); 

        return convertdLocalTime;
}
function draw_tabella() {

    var chart = $('#chart_div').highcharts();
    var series_chart = chart.series;
    var header_array = [];
    var header_value = [];
    var oggetto = {};
    var string_array = "";
    var string_array_precedent = "";
    var i = 0;
    oggetto = { "title": "Date" }
    header_array.push(oggetto)
    var date2_ms = parseDate(last_date, 'dd/mm/yy');
    var date1_ms = parseDate(init_date, 'dd/mm/yy');
    
    

    $.each(series_chart, function (row, series_chart_temp) {
        //if ((series_chart_temp.name != "Navigator") && (series_chart_temp.name != string_array_precedent)) {
        if ((series_chart_temp.name.indexOf("Navigator") < 0) && ((series_chart_temp.type != "scatter"))) {
            // if (string_array == "") {
            // string_array = string_array + '[{ "title": "' + series_chart_temp.name + '" }'
            //string_array = string_array + '"title": "' + series_chart_temp.name + '"'
            oggetto = { "title": series_chart_temp.name };
            header_array.push(oggetto);

            //header_value.push(point.);
        }
        string_array_precedent = series_chart_temp.name;
    });
    i = array_ch1.length - 1;
    
    $.each(array_ch1, function (row1, point1) {
        var array_temp = [];
        var date = new Date(array_ch1[i][0]);
        date = convertUTCDateToLocalDate(date);

        var theyear = date.getFullYear()
        var themonth = date.getMonth() + 1;
        var thetoday = date.getDate();
        var ore = date.getHours() ;
        var minuti = date.getUTCMinutes();
   
        var data_confronto = parseDate(thetoday + "/" + themonth + "/" + theyear, 'dd/mm/yy');
        
        /*var data_stringa = date.toString("dd/MM/yy");
        var data_finale = parseDate(data_stringa, 'dd/mm/yy');
        alert(data_finale);
        array_temp.push(data_finale.toString("dd/MM/yy"));
        */
        //alert(theyear + "/" + themonth + "/" + thetoday);
        
        if ((data_confronto >= date1_ms) && (data_confronto <= date2_ms)) {
            var date_complete = "";
            if (formato_data == '0') {//gg-mm-aa
                date_complete = get_numero_string(thetoday) + "/" + get_numero_string(themonth) + "/" + get_numero_string(theyear);
            }
            if (formato_data == '1') {//mm-gg-aa
                date_complete = get_numero_string(themonth) + "/" + get_numero_string(thetoday) + "/" + get_numero_string(theyear);
            }
            if (formato_data == '2') {//aa-mm-gg
                date_complete = get_numero_string(theyear) + "/" + get_numero_string(themonth) + "/" + get_numero_string(thetoday);
            }
            if (formato_time == '1') {// formato 12
                // var suffex = (ore >= 12)? 'pm' : 'am';
                var suffex = "";
               // alert(ore_temp);
                if (ore >= 12) {
                       suffex = "pm";
                }
                else {
                       suffex = "am";
                }
                if (ore > 12) {
                    ore = ore - 12;
                    if (ore == 0) ore = 12;
                }
                
                date_complete = date_complete + " " + get_numero_string(ore) + ":" + get_numero_string(minuti)  + " " + suffex;
                }
            else
            {
                date_complete = date_complete + " " + get_numero_string(ore) + ":" + get_numero_string(minuti)
                }
            array_temp.push(date_complete);
            
            //------------------------ch1
            if (($('#ch1_val_max5').is(':checked'))) {
                array_temp.push(array_ch1[i][1]);
            }

            if (($('#ch1_aa').is(':checked'))) {
                array_temp.push(on_off(array_aa1[i][1]));
            }
            if (($('#ch1_ab').is(':checked'))) {
                array_temp.push(on_off(array_ab1[i][1]));
            }
            if (($('#ch1_ad').is(':checked'))) {
                array_temp.push(on_off(array_ad1[i][1]));
            }
            if (($('#ch1_ar').is(':checked'))) {
                array_temp.push(on_off(array_ar1[i][1]));
            }
            //----------------------ch2
            if (($('#ch2_val_max5').is(':checked'))) {
                array_temp.push(array_ch2[i][1]);
            }

            if (($('#ch2_aa').is(':checked'))) {
                array_temp.push(on_off(array_aa2[i][1]));
            }
            if (($('#ch2_ab').is(':checked'))) {
                array_temp.push(on_off(array_ab2[i][1]));
            }
            if (($('#ch2_ad').is(':checked'))) {
                array_temp.push(on_off(array_ad2[i][1]));
            }
            if (($('#ch2_ar').is(':checked'))) {
                array_temp.push(on_off(array_ar2[i][1]));
            }
            //------------------------------ch3
            if (($('#ch3_val_max5').is(':checked'))) {
                array_temp.push(array_ch3[i][1]);
            }

            if (($('#ch3_aa').is(':checked'))) {
                array_temp.push(on_off(array_aa3[i][1]));
            }
            if (($('#ch3_ab').is(':checked'))) {
                array_temp.push(on_off(array_ab3[i][1]));
            }
            if (($('#ch3_ad').is(':checked'))) {
                array_temp.push(on_off(array_ad3[i][1]));
            }
            if (($('#ch3_ar').is(':checked'))) {
                array_temp.push(on_off(array_ar3[i][1]));
            }
            //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*ch4
            if (($('#ch4_val_max5').is(':checked'))) {
                array_temp.push(array_ch4[i][1]);
            }

            if (($('#ch4_aa').is(':checked'))) {
                array_temp.push(on_off(array_aa4[i][1]));
            }
            if (($('#ch4_ab').is(':checked'))) {
                array_temp.push(on_off(array_ab4[i][1]));
            }
            if (($('#ch4_ad').is(':checked'))) {
                array_temp.push(on_off(array_ad4[i][1]));
            }
            if (($('#ch4_ar').is(':checked'))) {
                array_temp.push(on_off(array_ar4[i][1]));
            }
            //----------------------------------ch5
            if (($('#ch5_val_max5').is(':checked'))) {
                array_temp.push(array_ch5[i][1]);
            }

            if (($('#ch5_aa').is(':checked'))) {
                array_temp.push(on_off(array_aa5[i][1]));
            }
            if (($('#ch5_ab').is(':checked'))) {
                array_temp.push(on_off(array_ab5[i][1]));
            }
            if (($('#ch5_ad').is(':checked'))) {
                array_temp.push(on_off(array_ad5[i][1]));
            }
            if (($('#ch5_ar').is(':checked'))) {
                array_temp.push(on_off(array_ar5[i][1]));
            }
            if ($('#temperature_max5').is(':checked'))
            {
                array_temp.push(array_temperatura[i][1]);
            }
            if (($('#flow_meter_max5').is(':checked'))) {
                array_temp.push(on_off(array_flow[i][1]));
            }

           
            
            header_value.push(array_temp);
        }
        i = i - 1;
    });
    
    // header_array.push(string_array);
    $('#chart_table_max5').html('<table cellpadding="0" cellspacing="0" border="0" class="display dynamicTable table table-striped table-bordered table-condensed" id="example"></table>');

    /*  $('#example').dataTable({
        "dom": 'T<"clear">lfrtip',
        "bSort": false,
        "tableTools": {
            "sSwfPath": "/chart/js/swf/copy_csv_xls_pdf.swf"
        },
        "data": header_value,
        "columns": header_array
    });*/
    $('#example').dataTable({
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        bSort: false,
        data: header_value,
        columns: header_array
    });
}
function on_off(ingresso) {
    if (ingresso == 1)
        return "ON"
    else
        return "OFF"
}
function get_numero_string(numero_valore) {
    if (numero_valore < 10)
        return "0" + numero_valore;
    else
        return numero_valore;
}

function manage_div() {

    if ($("#log_collapse").is(":visible")) {
        $("#log_collapse").hide();
    }
    else {
        $("#log_collapse").show();
    }
}
$("#head_log").click(function () {

    manage_div();

});