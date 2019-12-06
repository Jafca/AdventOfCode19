with Ada.Text_IO;           use Ada.Text_IO;
with Ada.Integer_Text_IO;   use Ada.Integer_Text_IO;

procedure Hello is
    type Arr is array (0 .. 200) of Integer;

    A : Arr;
    I : Integer := 0;
    N : Integer;
    C : Character;
    B : Boolean := True;
    S : Integer := 0;
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

    A(1) := 12;
    A(2) := 2;
    
    for J in 0 .. I loop
        if S = 0 then
            Exit when A(J) = 99;
            if A(J) = 1 then A(A(J+3)) := A(A(J+1)) + A(A(J+2));
            elsif A(J) = 2 then  A(A(J+3)) := A(A(J+1)) * A(A(J+2));
            end if;
            S := 3;
        else 
            S := S - 1;
        end if;
    end loop;

    Put_Line(Integer'Image(A(0)));
end Hello;