with Ada.Text_IO; 			use Ada.Text_IO;
with Ada.Integer_Text_IO; 	use Ada.Integer_Text_IO;

procedure Hello is
    N : Integer;
    S : Integer := 0;
    
    function Bye(X : Integer) return Integer is
        Y : Integer := 0;
        Z : Integer := X / 3 - 2;
    begin
        while Z > 0 loop
            Y := Y + Z;
            Z := Z / 3 - 2;
        end loop;
        return Y;
    end Bye;

begin
    while not Ada.Text_IO.End_Of_File loop
        Get(N);
        S := S + Bye(N);
        Skip_line;
    end loop;
    Put_Line(Integer'Image(S));
end Hello;