


def getFunc():
    print(" [sh(1)/sh(x)]-2x  : 1 ")
    print(" x+exp(-x)-exp(-1) : 2 ")
    print(" exp(x)-2          : 3 ")
    print(" 1-sin(x)-cos(x)   : 4 ")

    a = 0
    while(a < 1 or a > 4):
        a = int(input("Введите номер функции: "))
    return a

if __name__ == '__main__':
    N = 51
    a = [0]*N
    b = [0]*N
    c = [0]*N
    d = [0]*N
    V = [0]*N
    U = [0]*N
    Y = [0]*N

    numberFunc = getFunc()
