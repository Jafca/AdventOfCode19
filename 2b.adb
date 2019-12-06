with Ada.Text_IO;           use Ada.Text_IO;
with Ada.Integer_Text_IO;   use Ada.Integer_Text_IO;

procedure Hello is
    type Arr is array (0 .. 200) of Integer;

    A : Arr;
    T : Arr;
    I : Integer := 0;
    N : Integer;
    C : Character;
    B : Boolean := True;
    S : Integer;
begin
    while not Ada.Text_IO.End_Of_File loop
        if B then
            Get(N);
            A(I) := N;
            I := I + 1;
        else
            Get(C);
        end if;
        B := not B;
    end loop;

    for X in 0 .. 99 loop
        for Y in 0 .. 99 loop
            S := 0;
            T := A;
            T(1) := X;
            T(2) := Y;
        
            for J in 0 .. I loop
                if S = 0 then
                    Exit when T(J) = 99;
                    if T(J) = 1 then 
                        T(T(J+3)) := T(T(J+1)) + T(T(J+2));
                    elsif T(J) = 2 then 
                        T(T(J+3)) := T(T(J+1)) * T(T(J+2));
                    end if;
                    S := 3;
                else 
                    S := S - 1;
                end if;
            end loop;
        
            if T(0) = 19690720 then
                    Put_Line(Integer'Image(100 * X + Y));
            end if;
        end loop;
    end loop;
end Hello;