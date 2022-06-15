import time
import threading


def load_write():

    try:
        f1 = open('Fp1_FFT.txt', 'r')

        last_line = f1.readlines()[-1]
        split_line = last_line.split('\t')
        split_line = list(map(float, split_line[1:]))
        _13hz = sum(split_line[30 * 12 + 15:30 * 13 + 15])  # 13hz  -> 12.5 ~ 13.47 합
        _17hz = sum(split_line[30 * 16 + 15:30 * 17 + 15])  # 17hz  -> 16.5 ~ 17.47 합
        _30hz = sum(split_line[30 * 29 + 15:30 * 30 + 15])  # 30hz  -> 29.5 ~ 30.47 합
        _Beta = split_line[30 * 12] + split_line[30 * 16] + split_line[30 * 17]  # Beta 대역 합
        print(_13hz, _17hz, _30hz, _Beta)
        
        f2 = open("C:/Users/ssbe2/Desktop/13_17_30_data.txt", 'w')
        f2output = str(_13hz) + '\t' + str(_17hz) + '\t' + str(_30hz) + '\t' + str(_Beta)
        f2.write(f2output)
        f2.close()

        f1.close()

    except:
        pass

    threading.Timer(1, load_write).start()


load_write()



