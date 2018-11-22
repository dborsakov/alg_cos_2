import math
import pylab
import matplotlib.pyplot as plt

def getFunc():
    print(" [sh(1)/sh(x)]-2x  : 1 ")
    print(" x+exp(-x)-exp(-1) : 2 ")
    print(" exp(x)-2          : 3 ")
    print(" 1-sin(x)-cos(x)   : 4 ")

    a = 0
    while(a < 1 or a > 4):
        a = int(input("Введите номер функции: "))
    return a

def progonka(a,b,c,d,n):

    a, b, c, d = map(lambda k_list: list(map(float, k_list)), (a, b, c, d))

    v = [0]
    u = [0]
    n = len(d)
    x = [0]*n

    for i in range(1,n-1):
        v.append(-b[i]/(c[i]*v[i-1] + a[i]))
        u.append((d[i] - c[i]*u[i-1])/(c[i]*v[i-1] + a[i]))

    #x[n-1] = (d[n-1] - a[n-2]*u[n-1])/(c[n-1] + a[n-2]*v[n-1])
    x[0] = d[0]
    x[N-1] = d[N-1]
    for i in reversed(range(n-2)):
        x[i] = v[i+1]*x[i+1] + u[i+1]

    return x

if __name__ == '__main__':
    N = 51
    a = [0]*N
    b = [0]*N
    c = [0]*N
    d = [0]*N
    V = [0]*N
    U = [0]*N
    Y = [0]*N

    pylab.figure(1)

    numberFunc = getFunc()

    if(numberFunc == 1):
        d[0] = 0
        d[N-1] = -1
        h = 1/(N - 1)
        for i in range(1,N-1):
            a[i] = -2-h*h
            b[i] = 1
            c[i] = 1
        d[len(d)-1] = -1
        for i in range(1,N-1):
            d[i] = 2*math.pow(h,3)*(i-1)
            #print(i,end = " ")
        x = progonka(a,b,c,d,N)
        xx = []
        for i in range(0,N-2):
            xx.append(x[i])
        x = []
        for i in range(1,N-2):
            x.append((math.sinh(i)/math.sinh(1))-2*i)
        pylab.plot(xx, 'r')
        pylab.plot(x, 'b')

    pylab.show()
