// not C# script but py script, we refered as main algorithm and Idea
// just references

for(conut = 0;count<10;count++){
        pre_value13 += current_value13; 
        pre_value17 += current_value17; 
    }
r_13 = pre_value13/10;
r_17 = pre_value17/10;
runGame(r_13,r_17);
//10초에 대한 평균값을 구하는 함수 파일을 가져오는 함수에 넣어 rungame함수를 부를때 변수를 넣어 부르면 될듯. 
//current_value가 가장 최근에 가져온 값, pre_value가 그 직전의 가져온 값을 담는 변수 

int stay_focused():
    
    r_30 = 8E-13;
    r_veta = 2E-12;

    ssvep_state = 0; //초기상태, 집중하지 않은 상태
    //ssvep_state = 1 //30hz에 집중한 상태
    //ssvep_state =2 //veta파가 향상 된 상태
    //ssvep_state =3 //30hz, 베타파 모두 기준치 이상으로 상승한 상태

    line = fft_file.readline()
        if (line != NULL){  // fft 파일 생성되었으면
            ssvep_state = 0;  // 새로운 fft 파일이 생성되기 전까지는 상태가 유지된다.
            split_line = line.split('\t');
            split_line = list(map(float, split_line[1:])); // 문자열배열 int형으로 변환,맨 앞(시간)제외
            _30hz = split_line[5 * 30 +1]; // 30hz
            _veta = sum(split_line[5 * 12:5 * 18]);  // veta 13~17.80

            if (r_30  <= _30hz){
                ssvep_state = 1;

                if r_veta  <= _veta:
                    if (ssvep_state == 1)
                        ssvep_state = 3;  // 둘다 기준치 이상 올라감
                        return 1;
                    else:
                        ssvep_state = 2;
                        return 0;
            }

      
int runGame(int r_13, r_17):
    


    ssvep_state = 0; //초기상태, 집중하지 않은 상태
    //ssvep_state = 1; //13hz에 집중한 상태
    //ssvep_state =2; //17hz에 집중한 상태
  
    pick_up=0; //위의 물건 가져옴
    pick_down=0; //아래 물건 가져옴


    line = fft_file.readline()
    if line{  // fft 파일 생성되었으면
        ssvep_state = 0;  // 새로운 fft 파일이 생성되기 전까지는 상태가 유지된다.
        split_line = line.split('\t');
        split_line = list(map(float, split_line[1:]));  // 문자열배열 int형으로 변환,맨 앞(시간)제외
        _13hz = sum(split_line[5 * 16:5 * 18]);  // 13hz, 파일 읽기에서 값을 가져오면 수정예정
        _17hz = split_line[5 * 30 +1]; // 17hz, 파일 읽기에서 값을 가져오면 수정예정
        
        if (r_17 <= _17hz){//17평균이 그 전 10초보다 올라갈 경우
                ssvep_state = 2; 
        }//17hz가 올라가는 것이 잘뜨는 경향을 보이므로 17hz가 올라가면 17hz가 인식된것으로 보고 17hz가 내려가고 13hz가 올라갈 경우 13hz가 인
                //된것으로 본다 . 그외에는 17hz인식이라고 우선 표기한다.
        if (r_13 <= _13hz){
            if(ssvep_state = 0){
                ssvep_state = 1;
            }
            else
                ssvep_state = 2;
        }
        
    }   
    // --------------- 13인식
    if (ssvep_state == 1)  { 
        pick_up = 1;  
    }// 13 오름// 위쪽 물체 획득
    // --------------- 17인식
    else if (ssvep_state == 2){  
        pick_down = 1; 
    }// 17 오름// 아래쪽 물체 획득//위가 책일경우 if(pick_up == 1){state = true;}이런식으로 알고리즘 연결 
               }       `

  

    